using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using OpenTK.Graphics.OpenGL4;
using LearnOpenTK.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Mathematics;

namespace UTS_Grafkom_mantab
{
    class Mesh
    {
        List<Vector3> vertices = new List<Vector3>();
        List<Vector3> textureVertices = new List<Vector3>();
        List<Vector3> normals = new List<Vector3>();
        List<uint> vertexIndices = new List<uint>();
        int _vbo;
        int _ebo;
        int _vao;
        Shader _shader;
        Matrix4 transform;
        List<Mesh> child = new List<Mesh>();
        // Universal Function
        public Mesh()
        {

        }
        public void load()
        {
            _vbo = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, _vbo);
            GL.BufferData(BufferTarget.ArrayBuffer, vertices.Count * Vector3.SizeInBytes, vertices.ToArray(), BufferUsageHint.StaticDraw);
            _vbo = GL.GenVertexArray();
            GL.BindVertexArray(_vbo);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);
            if (vertexIndices.Count != 0)
            {
                _ebo = GL.GenBuffer();
                GL.BindBuffer(BufferTarget.ElementArrayBuffer, _ebo);
                GL.BufferData(BufferTarget.ElementArrayBuffer, vertexIndices.Count * sizeof(uint), vertexIndices.ToArray(), BufferUsageHint.StaticDraw);
            }
            _shader = new Shader("C:/Users/REPUBLIC OF GAMERS/Documents/grafikom/UTS_Grafkom/GrafKom/GrafKom/Shaders/natan/Shader_white.vert",
                           "C:/Users/REPUBLIC OF GAMERS/Documents/grafikom/UTS_Grafkom/GrafKom/GrafKom/Shaders/natan/Shader_white.frag");
            _shader.Use();
        }
        public void AddChild(Mesh i) {
            child.Add(i);
        }

        public Mesh GetChild(int index) {
            return child[index];
        }

        public List<Vector3> GetVertices()
        {
            return vertices;
        }
        public List<uint> GetVertexIndices()
        {
            return vertexIndices;
        }
        
        public void SetVertexIndices(List<uint> temp)
        {
            vertexIndices = temp;
        }

        public int GetVertexBufferObject()
        {
            return _vbo;
        }

        public int GetElementBufferObject()
        {
            return _ebo;
        }

        public int GetVertexArrayObject()
        {
            return _vao;
        }

        public Shader GetShader()
        {
            return _shader;
        }

        public Matrix4 GetTransform()
        {
            return transform;
        }
        public void Animate()
        {
            transform = transform * Matrix4.CreateRotationX(MathHelper.DegreesToRadians(0.05f));
            transform = transform * Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(0.05f));
        }
        public void Rotate(char coordinate = 'x', float how_much = 20f)
        {          
     
            if (coordinate == 'x')
            {

                transform = transform * Matrix4.CreateRotationX(MathHelper.DegreesToRadians(how_much));

                foreach (var meshobj in child)
                {
                    meshobj.Rotate('x');
                }
            }
            else if (coordinate == 'y')
            {
                transform = transform * Matrix4.CreateRotationY(MathHelper.DegreesToRadians(how_much));

                foreach (var meshobj in child)
                {
                    meshobj.Rotate('y');
                }
            }
            else if (coordinate == 'z')
            {
                transform = transform * Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(how_much));

                foreach (var meshobj in child)
                {
                    meshobj.Rotate('z');
                }
            }
        }
        public void Scale(float scale)
        {
            transform = transform * Matrix4.CreateScale(scale);

            foreach (var meshobj in child)
            {
                meshobj.Scale(scale);
            }
        }

        public void Translate(float tx, float ty, float tz)
        {
            transform = transform * Matrix4.CreateTranslation(tx, ty, tz);

            foreach (var meshobj in child)
            {
                meshobj.Translate(tx, ty, tz);
            }
        }

        public void LoadObjectFile(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("Unable to open \"" + path + "\", does not exist.");
            }

            using (StreamReader streamReader = new StreamReader(path))
            {
                while (!streamReader.EndOfStream)
                {
                    List<string> words = new List<string>(streamReader.ReadLine().ToLower().Split(' '));
                    words.RemoveAll(s => s == string.Empty);

                    if (words.Count == 0)
                        continue;

                    string type = words[0];
                    words.RemoveAt(0);


                    switch (type)
                    {
                        case "v":
                            vertices.Add(new Vector3(float.Parse(words[0]) / 10, float.Parse(words[1]) / 10, float.Parse(words[2]) / 10));
                               
                            break;

                        case "vt":
                            textureVertices.Add(new Vector3(float.Parse(words[0]), float.Parse(words[1]), words.Count < 3 ? 0 : float.Parse(words[2])));
                           
                            break;

                        case "vn":
                            normals.Add(new Vector3(float.Parse(words[0]), float.Parse(words[1]), float.Parse(words[2])));
                            break;

                        case "f":
                            foreach (string w in words)
                            {
                                if (w.Length == 0)
                                    continue;

                                string[] comps = w.Split('/');

                                vertexIndices.Add(uint.Parse(comps[0]) - 1);
                            }
                            break;

                        default:
                            break;
                    }
                }
            }
        }

        public void SetupObject(string vert, string frag)
        {
            transform = Matrix4.Identity;


            _vbo = GL.GenBuffer(); 
            GL.BindBuffer(BufferTarget.ArrayBuffer, _vbo);
            GL.BufferData<Vector3>(BufferTarget.ArrayBuffer,
                vertices.Count * Vector3.SizeInBytes,
                vertices.ToArray(),
                BufferUsageHint.StaticDraw);

            _vao = GL.GenVertexArray(); // vertex array object
            GL.BindVertexArray(_vao);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float,
                false, 3 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);

            _ebo = GL.GenBuffer(); // element buffer object
            GL.BindBuffer(BufferTarget.ElementArrayBuffer,
                _ebo);
            GL.BufferData(BufferTarget.ElementArrayBuffer,
                vertexIndices.Count * sizeof(uint),
                vertexIndices.ToArray(), BufferUsageHint.StaticDraw);

            _shader = new Shader(vert, frag);
            _shader.Use();

            //PrintVertexIndeces();
        }

        public void Render(/*Matrix4 camera_view, Matrix4 Camera_Projetion*/)
        {

            _shader.Use();
            _shader.SetMatrix4("transform", transform);
            //_shader.SetMatrix4("view", camera_view);
            //_shader.SetMatrix4("view", Camera_Projetion);
            GL.BindVertexArray(_vao);
            GL.DrawElements(PrimitiveType.Triangles,
                vertexIndices.Count,
                DrawElementsType.UnsignedInt, 0);

            foreach (var meshobj in child)
            {
                meshobj.Render();
            }
        }

        public void PrintVertexIndeces()
        {
            Console.Write("Vertex Indices: ");
            foreach (uint i in vertexIndices)
            {
                Console.Write(i + " ");
            }
            Console.Write('\n');
        }

        public void PrintVertices()
        {
            Console.Write("\nVertices: \n");
            foreach (Vector3 i in vertices)
            {
                Console.Write(i.X + " ");
            }
            Console.Write('\n');
            foreach (Vector3 i in vertices)
            {
                Console.Write(i.Y + " ");
            }
            Console.Write('\n');
            foreach (Vector3 i in vertices)
            {
                Console.Write(i.Z + " ");
            }
            Console.Write('\n');
        }

        // Shape Specific Function
        // Box
        public void CreateBoxVertices(float x, float y, float z, float len)
        {
            float _midX = x;
            float _midY = y;
            float _midZ = z;
            float _boxLength = len;

            Vector3 temp;

            // point 1
            temp.X = _midX - _boxLength / 2.0f;
            temp.Y = _midY + _boxLength / 2.0f;
            temp.Z = _midZ - _boxLength / 2.0f;
            vertices.Add(temp);

            // point 2
            temp.X = _midX + _boxLength / 2.0f;
            temp.Y = _midY + _boxLength / 2.0f;
            temp.Z = _midZ - _boxLength / 2.0f;
            vertices.Add(temp);

            // point 3
            temp.X = _midX - _boxLength / 2.0f;
            temp.Y = _midY - _boxLength / 2.0f;
            temp.Z = _midZ - _boxLength / 2.0f;
            vertices.Add(temp);

            // point 4
            temp.X = _midX + _boxLength / 2.0f;
            temp.Y = _midY - _boxLength / 2.0f;
            temp.Z = _midZ - _boxLength / 2.0f;
            vertices.Add(temp);

            // point 5
            temp.X = _midX - _boxLength / 2.0f;
            temp.Y = _midY + _boxLength / 2.0f;
            temp.Z = _midZ + _boxLength / 2.0f;
            vertices.Add(temp);

            // point 6
            temp.X = _midX + _boxLength / 2.0f;
            temp.Y = _midY + _boxLength / 2.0f;
            temp.Z = _midZ + _boxLength / 2.0f;
            vertices.Add(temp);

            // point 7
            temp.X = _midX - _boxLength / 2.0f;
            temp.Y = _midY - _boxLength / 2.0f;
            temp.Z = _midZ + _boxLength / 2.0f;
            vertices.Add(temp);

            // point 8
            temp.X = _midX + _boxLength / 2.0f;
            temp.Y = _midY - _boxLength / 2.0f;
            temp.Z = _midZ + _boxLength / 2.0f;
            vertices.Add(temp);

            vertexIndices = new List<uint>{
                // Segitiga Depan 1
                0, 1, 2,
                // Segitiga Depan 2
                1, 2, 3,
                // Segitiga Atas 1
                0, 4, 5,
                // Segitiga Atas 2
                0, 1, 5,
                // Segitiga Kanan 1
                1, 3, 5,
                // Segitiga Kanan 2
                3, 5, 7,
                // Segitiga Kiri 1
                0, 2, 4,
                // Segitiga Kiri 2
                2, 4, 6,
                // Segitiga Belakang 1
                4, 5, 6,
                // Segitiga Belakang 2
                5, 6, 7,
                // Segitiga Bawah 1
                2, 3, 6,
                // Segitiga Bawah 2
                3, 6, 7
            };
        }

    }
}