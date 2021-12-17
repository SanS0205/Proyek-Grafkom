using LearnOpenTK.Common;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
//using System.IO;
//using System.Text;
using OpenTK.Graphics.OpenGL4;

namespace UTS_Grafkom_mantab
{
    class Natanael_lalujan
    {
        List<Vector3> vertices = new List<Vector3>();
        List<uint> vertexIndices = new List<uint>();
        int _vbo;
        int _vao;
        int _ebo;
        Shader _shader;
        Matrix4 transform;
        public List<Natanael_lalujan> child = new List<Natanael_lalujan>();
        public void SetupObject(string vert, string frag)
        {
            transform = Matrix4.Identity;
            _vbo = GL.GenBuffer(); 
            GL.BindBuffer(BufferTarget.ArrayBuffer, _vbo);
            GL.BufferData<Vector3>(BufferTarget.ArrayBuffer,
                vertices.Count * Vector3.SizeInBytes,
                vertices.ToArray(),
                BufferUsageHint.StaticDraw);

            _vao = GL.GenVertexArray(); 
            GL.BindVertexArray(_vao);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float,
                false, 3 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);

            _ebo = GL.GenBuffer(); 
            GL.BindBuffer(BufferTarget.ElementArrayBuffer,
                _ebo);
            GL.BufferData(BufferTarget.ElementArrayBuffer,
                vertexIndices.Count * sizeof(uint),
                vertexIndices.ToArray(), BufferUsageHint.StaticDraw);

            _shader = new Shader(vert, frag);
            _shader.Use();        
        }
        public int GetElementBufferObject()
        {
            return _ebo;
        }
      
        public void Render(string mode = "normal")
        {
            _shader.Use();
            _shader.SetMatrix4("transform", transform);
            GL.BindVertexArray(_vao);
            GL.DrawArrays(PrimitiveType.Lines, 0, vertices.Count);

            foreach (var meshobj in child)
            {
                meshobj.Render();
            }
        }       

        public int GetVertexBufferObject()
        {
            return _vbo;
        }

        public int GetVertexArrayObject()
        {
            return _vao;
        }

        public Shader GetShader()
        {
            return _shader;
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
        public void Scale(float m = 0.9f)
        {

            transform = transform * Matrix4.CreateScale(m);


        }      
            
        public void createEllipsoid2(float radiusX, float radiusY, float radiusZ, float _x, float _y, float _z, int sectorCount, int stackCount)
        {
            float pi = (float)Math.PI;
            Vector3 temp_vector;

            float sectorStep = 2 * (float)Math.PI / sectorCount;
            float stackStep = (float)Math.PI / stackCount;
            float sectorAngle, StackAngle, x, y, z;

            for (int i = 0; i < stackCount; ++i)
            {
                StackAngle = pi / 2 - i * stackStep;
                x = radiusX * (float)Math.Cos(StackAngle);
                y = radiusY * (float)Math.Cos(StackAngle);
                z = radiusZ * (float)Math.Sin(StackAngle);

                for (int j = 0; j <= sectorCount; ++j)
                {
                    sectorAngle = j * sectorStep;
                    temp_vector.Z = y * (float)Math.Cos(sectorAngle);
                    temp_vector.X = x * (float)Math.Sin(sectorAngle);
                    temp_vector.Y = z;
                    vertices.Add(temp_vector);
                }
            }
            uint k1, k2;
            for (int i = 0; i < stackCount; ++i)
            {
                k1 = (uint)(i * (sectorCount + 1));
                k2 = (uint)(k1 + sectorCount + 1);
                for (int j = 0; j < sectorCount; ++j, ++k1, ++k2)
                {
                    if (i != 0)
                    {
                        vertexIndices.Add(k1);
                        vertexIndices.Add(k2);
                        vertexIndices.Add(k1 + 1);
                    }
                    if (i != (stackCount - 1))
                    {
                        vertexIndices.Add(k1 + 1);
                        vertexIndices.Add(k2);
                        vertexIndices.Add(k2 + 1);
                    }
                }
            }
        }
        public float createEllipsoid(float _x_pos, float _y_pos, float _z_pos, float _radiusX, float _radiusY, float _radiusZ)
        {
            Vector3 temp_vector;
            float pi = 3.14159f;

            for (float u = -pi; u <= pi; u += pi / 300)
            {
                for (float v = -pi / 2; v < pi / 2; v += pi / 300)
                {
                    temp_vector.X = _x_pos + _radiusX * (float)Math.Cos(v) * (float)Math.Cos(u); 
                    temp_vector.Y = _y_pos + _radiusY * (float)Math.Cos(v) * (float)Math.Sin(u); 
                    temp_vector.Z = _z_pos + _radiusZ * (float)Math.Sin(v); 
                    vertices.Add(temp_vector);
                }
            }
            return 0.0f;
        }

        public float CreateEllipsoidVertices(float _x_pos, float _y_pos, float _z_pos, float _radiusX, float _radiusY, float _radiusZ)
        {           
            Vector3 temp_vector;
         
            float pi = 3.14159f;

            for (float u = -pi; u <= pi; u += pi / 500)
            {
                for (float v = -pi / 2; v < pi / 2; v += pi / 500)
                {
                    temp_vector.X = _x_pos + _radiusX * (float)Math.Cos(v) * (float)Math.Cos(u); 
                    temp_vector.Y = _y_pos + _radiusY * (float)Math.Cos(v) * (float)Math.Sin(u); 
                    temp_vector.Z = _z_pos + _radiusZ * (float)Math.Sin(v); 
                    vertices.Add(temp_vector);
                }
            }
            return 0.0f;
        }


        public float createEllipsoid2(float _x_pos, float _y_pos, float _z_pos, float _radiusX, float _radiusY, float _radiusZ)
        {
            Vector3 temp_vector;
            float pi = 3.14159f;

            for (float u = -pi; u <= pi; u += pi / 100)
            {
                for (float v = -pi / 2; v < pi / 5; v += pi / 100)
                {
                    temp_vector.X = _x_pos + _radiusX * (float)Math.Cos(v) * (float)Math.Cos(u); 
                    temp_vector.Y = _y_pos + _radiusY * (float)Math.Cos(v) * (float)Math.Sin(u); 
                    temp_vector.Z = _z_pos + _radiusZ * (float)Math.Sin(v);
                    vertices.Add(temp_vector);
                }
            }
            return 0.0f;
        }

        public float CreateHalfEllipsoi(float _x_pos, float _y_pos, float _z_pos, float _radiusX, float _radiusY, float _radiusZ)
        {
            Vector3 temp_vector;
            float pi = 3.14159f;

            for (float u = -pi; u <= pi; u += pi / 550)
            {
                for (float v = -pi; v < pi / 2; v += pi / 550)
                {
                    temp_vector.X = _x_pos + _radiusX * (float)Math.Cos(v) * (float)Math.Cos(u); 
                    temp_vector.Y = _y_pos + _radiusY * (float)Math.Cos(v) * (float)Math.Sin(u); 
                    temp_vector.Z = _z_pos + _radiusZ * (float)Math.Sin(v);
                    vertices.Add(temp_vector);
                }
            }
            return 0.0f;
        }     
        public float CreateUniqEllipsoidVertices2(float _x_pos, float _y_pos, float _z_pos, float _radiusX, float _radiusY, float _radiusZ)
        {
            Vector3 temp_vector;

            float pi = 3.14159f;

            for (float u = -pi; u <= pi; u += pi / 300)
            {
                for (float v = 0; v < pi / 10; v += pi / 300)
                {
                    temp_vector.Z = _x_pos + _radiusX * (float)Math.Cos(v) * (float)Math.Cos(u);
                    temp_vector.X = _y_pos + _radiusY * (float)Math.Cos(v) * (float)Math.Sin(u); 
                    temp_vector.Y = _z_pos + _radiusZ * (float)Math.Sin(v); 
                    vertices.Add(temp_vector);
                }
            }

            return 0.0f;
        }

       
    }
}