using System.Diagnostics;

namespace Expanding_Langton_s_And;

static class Program {
    static GLSShader shader;
    static Stopwatch stopwatch = new();
    static float scaleInvert = 150;
    public static CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
    public static ManualResetEvent manualResetEvent = new ManualResetEvent(true);
    public static int steps = 0;
    public static float DeltaTime => stopwatch.ElapsedMilliseconds / 1000f;
    static Form1 Form1;
    [STAThread]
    static void Main() {
        ApplicationConfiguration.Initialize();
        GLSWindow.RegisterOnInit(Init);
        GLSWindow.RegisterOnRendering(Render);
        GLSWindow.RegisterOnClosing(Close);
        GLSWindow.RegisterOnScrollRolling(ScrollRoll);
        GLSWindow.Init(800, 800, "Langton's Ant");

        LantongsAnt.Get();

        Form1 = new();
        Form1.Show();

        Task.Run(LangtonSAntSimulator, cancellationTokenSource.Token);
        manualResetEvent.Reset();

        while (!GLSWindow.ShouldClose()) {
            GLSWindow.Render();
            stopwatch.Stop();
            stopwatch.Restart();
        }

        cancellationTokenSource.Cancel();
        GLSWindow.Close();
    }

    static void Init() {
        shader = new GLSShader(File.ReadAllText("Shader.vsh"), File.ReadAllText("Shader.psh"));
    }

    static void Render() {
        shader.Use();
        shader.SetMatrix("u_matrix", SMatrix.CreateOrthographic(scaleInvert * GLSWindow.GetWidth() / GLSWindow.GetHeight(), scaleInvert, 0.001f, 1000f), false);
        GLSMesh mesh = LantongsAnt.GetMesh();
        mesh.Flush();
        GC.SuppressFinalize(mesh);
        GC.Collect();
        Form1.Text = $"设置 {steps}";
    }

    static void Close() {
    }

    static void ScrollRoll(float x, float y) {
        Console.WriteLine(DeltaTime);
        scaleInvert += y * DeltaTime * 100;
    }

    static void LangtonSAntSimulator() {
        Random random = new Random();
        while (steps < 1E7 && !cancellationTokenSource.IsCancellationRequested) {
            manualResetEvent.WaitOne();
            LantongsAnt.Step();
            if (random.Next(1, 10) < 2) Thread.Sleep(1);
            steps++;
        }
    }
}