namespace Expanding_Langton_s_And {

    public static class LantongsAnt {
        public static Dictionary<SColor, bool> operations = new()
        {
            {new SColor(0, 0, 0) , true},
            {new SColor(255, 255, 255) , false},
        };
        public static Dictionary<SVector2, SColor> gird = new();

        public static Ant ant;

        public static void Step() {
            SColor color = gird.TryGetValue(ant.position, out SColor value) ? value : new SColor(0, 0, 0);
            bool r = operations.GetValueOrDefault(color, true);

            //旋转
            ant.Rotate(r);

            //改变格子
            int indexOfOperation = operations.TakeWhile(operation => operation.Key.r != color.r || operation.Key.g != color.g || operation.Key.b != color.b).Count();
            indexOfOperation++;
            if (indexOfOperation >= operations.Count) indexOfOperation = 0;
            gird[ant.position] = operations.ElementAt(indexOfOperation).Key;

            //移动蚂蚁
            ant.Move();
        }

        public static void Get() {
            if (File.Exists("Operations.txt")) {
                operations.Clear();
                string operationsData = File.ReadAllText("Operations.txt");
                string[] operationItems = operationsData.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
                foreach (var operationText in operationItems) {
                    string[] data = operationText.Split(' ');
                    SColor color = new(int.Parse(data[0]), int.Parse(data[1]), int.Parse(data[2]));
                    bool rotate = data[3] == "R";
                    operations.Add(color, rotate);
                }
            }
        }

        public static GLSMesh GetMesh() {
            List<GLSVertex> vertices = new();
            List<uint> indices = new();

            SVector3 v1 = new(0, 0, 0);
            SVector3 v2 = new(0, 1, 0);
            SVector3 v3 = new(1, 1, 0);
            SVector3 v4 = new(1, 0, 0);
            //添加格子
            uint index = 0;
            Dictionary<SVector2, SColor> girdCache = new(gird);
            foreach (var cell in girdCache) {
                vertices.Add(new GLSVertex(v1 + new SVector3(cell.Key.x, cell.Key.y, 0), cell.Value, new SVector3(0, 0, 1), new SVector2(0, 0)));
                vertices.Add(new GLSVertex(v2 + new SVector3(cell.Key.x, cell.Key.y, 0), cell.Value, new SVector3(0, 0, 1), new SVector2(0, 1)));
                vertices.Add(new GLSVertex(v3 + new SVector3(cell.Key.x, cell.Key.y, 0), cell.Value, new SVector3(0, 0, 1), new SVector2(1, 1)));
                vertices.Add(new GLSVertex(v4 + new SVector3(cell.Key.x, cell.Key.y, 0), cell.Value, new SVector3(0, 0, 1), new SVector2(1, 0)));
                indices.AddRange([0u + index, 1u + index, 2u + index, 0u + index, 2u + index, 3u + index]);
                index += 4;
            }

            //添加蚂蚁
            SVector3 v1_Ant = new(0.2f, 0.2f, 0);
            SVector3 v2_Ant = new(0.2f, 0.8f, 0);
            SVector3 v3_Ant = new(0.8f, 0.8f, 0);
            SVector3 v4_Ant = new(0.8f, 0.2f, 0);
            vertices.Add(new GLSVertex(v1_Ant + new SVector3(ant.position.x, ant.position.y, 0), new SColor(0, 255, 255), new SVector3(0, 0, 1), new SVector2(0, 0)));
            vertices.Add(new GLSVertex(v2_Ant + new SVector3(ant.position.x, ant.position.y, 0), new SColor(0, 255, 255), new SVector3(0, 0, 1), new SVector2(0, 1)));
            vertices.Add(new GLSVertex(v3_Ant + new SVector3(ant.position.x, ant.position.y, 0), new SColor(0, 255, 255), new SVector3(0, 0, 1), new SVector2(1, 1)));
            vertices.Add(new GLSVertex(v4_Ant + new SVector3(ant.position.x, ant.position.y, 0), new SColor(0, 255, 255), new SVector3(0, 0, 1), new SVector2(1, 0)));
            indices.AddRange([0u + index, 1u + index, 2u + index, 0u + index, 2u + index, 3u + index]);

            return new GLSMesh(vertices.ToArray(), indices.ToArray());
        }
    }

    public struct Ant {
        public int direction;
        public SVector2 position;

        public static SVector2[] directionAxes = [new SVector2(1, 0), new SVector2(0, -1), new SVector2(-1, 0), new SVector2(0, 1)];

        public void Rotate(bool r) {
            direction += r ? 1 : -1;
            direction = (direction % 4 + 4) % 4;
        }

        public void Move() {
            position += directionAxes[direction];
        }
    }
}