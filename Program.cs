namespace Expanding_Langton_s_And;

static class Program {
    [STAThread]
    static void Main() {
        ApplicationConfiguration.Initialize();
        GLSWindow.Init(800, 800, "Langton's Ant");

        Form1 form1 = new();
        form1.Show();

        while (!GLSWindow.ShouldClose()) {
            GLSWindow.Render();
        }

        GLSWindow.Close();
    }
}