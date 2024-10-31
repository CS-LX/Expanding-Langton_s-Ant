using System.Diagnostics;

namespace Expanding_Langton_s_And;

static class Program {
    static GLSShader shader;
    static Stopwatch stopwatch = new();
    static float scaleInvert = 10;
    public static float DeltaTime => stopwatch.ElapsedMilliseconds / 1000f;
    [STAThread]
    static void Main() {
        ApplicationConfiguration.Initialize();
        GLSWindow.RegisterOnInit(Init);
        GLSWindow.RegisterOnRendering(Render);
        GLSWindow.RegisterOnClosing(Close);
        GLSWindow.RegisterOnScrollRolling(ScrollRoll);
        GLSWindow.Init(800, 800, "Langton's Ant");

        Form1 form1 = new();
        form1.Show();

        while (!GLSWindow.ShouldClose()) {
            GLSWindow.Render();
            stopwatch.Stop();
            stopwatch.Restart();
        }

        GLSWindow.Close();
    }

    static void Init() {
        shader = new GLSShader(File.ReadAllText("Shader.vsh"), File.ReadAllText("Shader.psh"));
    }

    static void Render() {
        shader.Use();
        shader.SetMatrix("u_matrix", SMatrix.CreateOrthographic(scaleInvert * GLSWindow.GetWidth() / GLSWindow.GetHeight(), scaleInvert, 0.001f, 1000f), false);
        LantongsAnt.GetMesh().Flush();
        LantongsAnt.Step();
    }

    static void Close() {
    }

    static void ScrollRoll(float x, float y) {
        Console.WriteLine(DeltaTime);
        scaleInvert += y * DeltaTime * 100;
    }
}