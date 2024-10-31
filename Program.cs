namespace Expanding_Langton_s_And;

static class Program {
    static GLSShader shader;

    [STAThread]
    static void Main() {
        ApplicationConfiguration.Initialize();
        GLSWindow.RegisterOnInit(Init);
        GLSWindow.RegisterOnRendering(Render);
        GLSWindow.RegisterOnClosing(Close);
        GLSWindow.Init(800, 800, "Langton's Ant");

        Form1 form1 = new();
        form1.Show();

        while (!GLSWindow.ShouldClose()) {
            GLSWindow.Render();
        }

        GLSWindow.Close();
    }

    static void Init() {
        shader = new GLSShader(File.ReadAllText("Shader.vsh"), File.ReadAllText("Shader.psh"));
    }

    static void Render() {
        shader.Use();
        shader.SetMatrix("u_matrix", SMatrix.CreateScale(0.1f), false);
        LantongsAnt.GetMesh().Flush();
        LantongsAnt.Step();
    }

    static void Close() {
    }
}