namespace Expanding_Langton_s_And;

public partial class Form1 : Form {
    public Form1() {
        InitializeComponent();
        startButton.Click += StartButtonOnClick;
        pauseButton.Click += PauseButtonOnClick;
        stopBotton.Click += StopBottonOnClick;
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
}