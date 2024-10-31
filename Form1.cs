using System.ComponentModel;

namespace Expanding_Langton_s_And;

public partial class Form1 : Form {
    private BindingList<ObservableKeyValue> bindingList;
    public Form1() {
        InitializeComponent();
        startButton.Click += StartButtonOnClick;
        pauseButton.Click += PauseButtonOnClick;
        stopBotton.Click += StopBottonOnClick;

        bindingList = new BindingList<ObservableKeyValue>(
            LantongsAnt.operations.Select(kv => new ObservableKeyValue { Key = kv.Key, Value = kv.Value }).ToList());
        stepsList.DataSource = bindingList;
        stepsList.DisplayMember = "Key";  // 显示的内容
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