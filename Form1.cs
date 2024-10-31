using System.ComponentModel;

namespace Expanding_Langton_s_And;

public partial class Form1 : Form {
    private BindingList<ObservableKeyValue> bindingList;
    public Form1() {
        InitializeComponent();
        startButton.Click += StartButtonOnClick;
        pauseButton.Click += PauseButtonOnClick;
        stopBotton.Click += StopBottonOnClick;
        minusButton.Click += MinusButtonOnClick;
        addButton.Click += AddButtonOnClick;
        colorButton.Click += ColorButtonOnClick;
        rotateButton.Click += RotateButtonOnClick;

        bindingList = new BindingList<ObservableKeyValue>(
            LantongsAnt.operations.Select(kv => new ObservableKeyValue { Key = kv.Key, Value = kv.Value }).ToList());
        stepsList.DataSource = bindingList;
        stepsList.DisplayMember = "Key";  // 显示的内容
        stepsList.SelectedValueChanged += StepsListOnSelectedValueChanged;
    }

    void RotateButtonOnClick(object? sender, EventArgs e) {
        if (stepsList.SelectedItem != null && LantongsAnt.operations.Count > 1) {
            UpdateDictionary(((ObservableKeyValue)stepsList.SelectedItem).Key, !LantongsAnt.operations[((ObservableKeyValue)stepsList.SelectedItem).Key]);
        }
        UpdateUI();
    }

    void ColorButtonOnClick(object? sender, EventArgs e) {
    }

    void StepsListOnSelectedValueChanged(object? sender, EventArgs e) {
        UpdateUI();
    }

    void AddButtonOnClick(object? sender, EventArgs e) {
        SColor color = new(0, 0, 0, 1);
        ColorDialog colorDialog = new();
        do {
            if (colorDialog.ShowDialog() == DialogResult.OK) {
                color = new SColor(colorDialog.Color.R, colorDialog.Color.G, colorDialog.Color.B);
            }
            else {
                return;
            }
            if (LantongsAnt.operations.ContainsKey(color)) {
                MessageBox.Show("颜色重复");
            }
        }
        while (LantongsAnt.operations.ContainsKey(color));
        AddToDictionary(color, false);
        UpdateUI();
    }

    void MinusButtonOnClick(object? sender, EventArgs e) {
        if (stepsList.SelectedItem != null && LantongsAnt.operations.Count > 1) {
            RemoveFromDictionary(((ObservableKeyValue)stepsList.SelectedItem).Key);
        }
        UpdateUI();
    }

    void StopBottonOnClick(object? sender, EventArgs e) {
        Program.manualResetEvent.Reset();
        LantongsAnt.ant.position = new SVector2(0);
        LantongsAnt.ant.direction = 0;
        LantongsAnt.gird.Clear();
    }

    void PauseButtonOnClick(object? sender, EventArgs e) {
        Program.manualResetEvent.Reset();
    }

    void StartButtonOnClick(object? sender, EventArgs e) {
        Program.manualResetEvent.Set();
    }

    void UpdateUI() {
        if (stepsList.SelectedItem == null) {
            colorButton.Text = "颜色";
            rotateButton.Text = "旋转";
            colorButton.Enabled = rotateButton.Enabled = false;
            return;
        }
        ObservableKeyValue v = (ObservableKeyValue)stepsList.SelectedItem;
        colorButton.Enabled = rotateButton.Enabled = true;
        colorButton.Text = v.Key.ToString();
        rotateButton.Text = v.Value ? "R" : "L";
    }

    private void UpdateDictionary(SColor key, bool newValue)
    {
        if (LantongsAnt.operations.ContainsKey(key))
        {
            LantongsAnt.operations[key] = newValue;

            var item = bindingList.FirstOrDefault(x => x.Key == key);
            if (item != null)
            {
                item.Value = newValue; // 触发 INotifyPropertyChanged
            }
        }
    }

    private void AddToDictionary(SColor key, bool value)
    {
        LantongsAnt.operations[key] = value;
        bindingList.Add(new ObservableKeyValue { Key = key, Value = value });
    }

    private void RemoveFromDictionary(SColor key)
    {
        if (LantongsAnt.operations.Remove(key))
        {
            var item = bindingList.FirstOrDefault(x => x.Key == key);
            if (item != null)
            {
                bindingList.Remove(item);
            }
        }
    }
}