using System;
using System.Collections.Generic;
using System.Text;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Graphics.OpenGL4;
using LearnOpenTK.Common;
using OpenTK.Mathematics;
using System.Threading;
using System.IO;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace UTS_Grafkom_mantab
{

    class Project_UTS : GameWindow
    {
        Mesh[] Object3D = new Mesh[3];
        Natanael_lalujan head1 = new Natanael_lalujan();
        Natanael_lalujan head2 = new Natanael_lalujan();
        Natanael_lalujan nose = new Natanael_lalujan();
        Natanael_lalujan left_eye = new Natanael_lalujan();
        Natanael_lalujan right_eye = new Natanael_lalujan();
        Natanael_lalujan left_eye2 = new Natanael_lalujan();
        Natanael_lalujan right_eye2 = new Natanael_lalujan();
        Natanael_lalujan pocket = new Natanael_lalujan();
        Natanael_lalujan left_hand = new Natanael_lalujan();
        Natanael_lalujan right_hand = new Natanael_lalujan();
        Natanael_lalujan left_foot = new Natanael_lalujan();
        Natanael_lalujan right_foot = new Natanael_lalujan();
        Natanael_lalujan body = new Natanael_lalujan();
        Natanael_lalujan necklace = new Natanael_lalujan();
        Mesh kasursponge = new Mesh();
        Mesh lenganbaju = new Mesh();
        Mesh celana = new Mesh();
        Mesh dasi = new Mesh();       
        Mesh mata = new Mesh();
        Mesh sponbody = new Mesh();
        Mesh badanminion = new Mesh();
        Mesh kacamata = new Mesh();
        Mesh sepatu = new Mesh();
        Mesh tiang = new Mesh();
        Mesh sandaran = new Mesh();
        //Camera _camera;
        //transformasi
        private Matrix4 transform;
        
        // ================SPONGEBOB========================
        //Ricky C14180192
        // Body, warna kuning.
        string path_body = "C:/Users/REPUBLIC OF GAMERS/Documents/grafikom/UTS_Grafkom/GrafKom/GrafKom/asset/spongebob/badansponge.obj";
        string vert_body = "C:/Users/REPUBLIC OF GAMERS/Documents/grafikom/UTS_Grafkom/GrafKom/GrafKom/Shaders/shader_body.vert";
        string frag_body = "C:/Users/REPUBLIC OF GAMERS/Documents/grafikom/UTS_Grafkom/GrafKom/GrafKom/Shaders/shader_body.frag";
        //mata, warna putih
        string path_mata = "C:/Users/REPUBLIC OF GAMERS/Documents/grafikom/UTS_Grafkom/GrafKom/GrafKom/asset/spongebob/mata.obj";
        string vert_mata = "C:/Users/REPUBLIC OF GAMERS/Documents/grafikom/UTS_Grafkom/GrafKom/GrafKom/Shaders/shader_mata.vert";
        string frag_mata = "C:/Users/REPUBLIC OF GAMERS/Documents/grafikom/UTS_Grafkom/GrafKom/GrafKom/Shaders/shader_mata.frag";
        // lengan baju, putih.
        string path_lenganbaju = "C:/Users/REPUBLIC OF GAMERS/Documents/grafikom/UTS_Grafkom/GrafKom/GrafKom/asset/spongebob/bajuputih.obj";
        string vert_lenganbaju = "C:/Users/REPUBLIC OF GAMERS/Documents/grafikom/UTS_Grafkom/GrafKom/GrafKom/Shaders/shader_lenganbaju.vert";
        string frag_lenganbaju = "C:/Users/REPUBLIC OF GAMERS/Documents/grafikom/UTS_Grafkom/GrafKom/GrafKom/Shaders/shader_lenganbaju.frag";
        // celana, warna cokelat.
        string path_celana = "C:/Users/REPUBLIC OF GAMERS/Documents/grafikom/UTS_Grafkom/GrafKom/GrafKom/asset/spongebob/celanacoklat.obj";
        string vert_celana = "C:/Users/REPUBLIC OF GAMERS/Documents/grafikom/UTS_Grafkom/GrafKom/GrafKom/Shaders/shader_celana.vert";
        string frag_celana = "C:/Users/REPUBLIC OF GAMERS/Documents/grafikom/UTS_Grafkom/GrafKom/GrafKom/Shaders/shader_celana.frag";
        //dasi, warna merah
        string path_dasi = "C:/Users/REPUBLIC OF GAMERS/Documents/grafikom/UTS_Grafkom/GrafKom/GrafKom/asset/spongebob/dasi.obj";
        string vert_dasi = "C:/Users/REPUBLIC OF GAMERS/Documents/grafikom/UTS_Grafkom/GrafKom/GrafKom/Shaders/shader_dasi.vert";
        string frag_dasi = "C:/Users/REPUBLIC OF GAMERS/Documents/grafikom/UTS_Grafkom/GrafKom/GrafKom/Shaders/shader_dasi.frag";
        // ==============MINION======================
        //Natanael lalujan C14180204
        //badan kuning
        string minion = "C:/Users/REPUBLIC OF GAMERS/Documents/grafikom/UTS_Grafkom/GrafKom/GrafKom/asset/minion/badanminion.obj";
        string vert_mini = "C:/Users/REPUBLIC OF GAMERS/Documents/grafikom/UTS_Grafkom/GrafKom/GrafKom/Shaders/shader_mini.vert";
        string frag_mini = "C:/Users/REPUBLIC OF GAMERS/Documents/grafikom/UTS_Grafkom/GrafKom/GrafKom/Shaders/shader_mini.frag";
        //kacamata
        string kacamataminion = "C:/Users/REPUBLIC OF GAMERS/Documents/grafikom/UTS_Grafkom/GrafKom/GrafKom/asset/minion/kacamata.obj";
        string vert_kcmt = "C:/Users/REPUBLIC OF GAMERS/Documents/grafikom/UTS_Grafkom/GrafKom/GrafKom/Shaders/mata_minion.vert";
        string frag_kcmt = "C:/Users/REPUBLIC OF GAMERS/Documents/grafikom/UTS_Grafkom/GrafKom/GrafKom/Shaders/mata_minion.frag";
        //sepatu
        string sepatuminion = "C:/Users/REPUBLIC OF GAMERS/Documents/grafikom/UTS_Grafkom/GrafKom/GrafKom/asset/minion/sepatu.obj";
        string vert_sepatu = "C:/Users/REPUBLIC OF GAMERS/Documents/grafikom/UTS_Grafkom/GrafKom/GrafKom/Shaders/sepatu_minion.vert";
        string frag_sepatu = "C:/Users/REPUBLIC OF GAMERS/Documents/grafikom/UTS_Grafkom/GrafKom/GrafKom/Shaders/sepatu_minion.frag";
        // ============== kasur spongebob======================
        string spongebobed = "C:/Users/REPUBLIC OF GAMERS/Documents/grafikom/UTS_Grafkom/GrafKom/GrafKom/asset/spongebed/kasur.obj";
        string vert_bed = "C:/Users/REPUBLIC OF GAMERS/Documents/grafikom/UTS_Grafkom/GrafKom/GrafKom/Shaders/shader_kasur.vert";
        string frag_bed = "C:/Users/REPUBLIC OF GAMERS/Documents/grafikom/UTS_Grafkom/GrafKom/GrafKom/Shaders/shader_kasur.frag";
        //tiang
        string tiangkasur = "C:/Users/REPUBLIC OF GAMERS/Documents/grafikom/UTS_Grafkom/GrafKom/GrafKom/asset/spongebed/tiang.obj";
        string vert_tiang = "C:/Users/REPUBLIC OF GAMERS/Documents/grafikom/UTS_Grafkom/GrafKom/GrafKom/Shaders/shader_tiang.vert";
        string frag_tiang = "C:/Users/REPUBLIC OF GAMERS/Documents/grafikom/UTS_Grafkom/GrafKom/GrafKom/Shaders/shader_tiang.frag";
        //sandaran
        string sandarankasur = "C:/Users/REPUBLIC OF GAMERS/Documents/grafikom/UTS_Grafkom/GrafKom/GrafKom/asset/spongebed/torus.obj";
        string vert_sandar = "C:/Users/REPUBLIC OF GAMERS/Documents/grafikom/UTS_Grafkom/GrafKom/GrafKom/Shaders/shader_torus.vert";
        string frag_sandar = "C:/Users/REPUBLIC OF GAMERS/Documents/grafikom/UTS_Grafkom/GrafKom/GrafKom/Shaders/shader_torus.frag";
        //lantai
        string lantai1 = "C:/Users/REPUBLIC OF GAMERS/Documents/grafikom/UTS_Grafkom/GrafKom/GrafKom/asset/lantai/lantai.obj";
        string vert_lantai = "C:/Users/REPUBLIC OF GAMERS/Documents/grafikom/UTS_Grafkom/GrafKom/GrafKom/Shaders/natan/lantai.vert";
        string frag_lantai = "C:/Users/REPUBLIC OF GAMERS/Documents/grafikom/UTS_Grafkom/GrafKom/GrafKom/Shaders/natan/lantai.frag";
        // ============== doraemon======================
        //Natanael lalujan C14180204
        string vert_white = "C:/Users/REPUBLIC OF GAMERS/Documents/grafikom/UTS_Grafkom/GrafKom/GrafKom/Shaders/warna_putih.vert";
        string frag_white = "C:/Users/REPUBLIC OF GAMERS/Documents/grafikom/UTS_Grafkom/GrafKom/GrafKom/Shaders/warna_putih.frag";
        string vert_blue = "C:/Users/REPUBLIC OF GAMERS/Documents/grafikom/UTS_Grafkom/GrafKom/GrafKom/Shaders/kulit.vert";
        string frag_blue = "C:/Users/REPUBLIC OF GAMERS/Documents/grafikom/UTS_Grafkom/GrafKom/GrafKom/Shaders/kulit.frag";
        string vert_red = "C:/Users/REPUBLIC OF GAMERS/Documents/grafikom/UTS_Grafkom/GrafKom/GrafKom/Shaders/warna_hidung.vert";
        string frag_red = "C:/Users/REPUBLIC OF GAMERS/Documents/grafikom/UTS_Grafkom/GrafKom/GrafKom/Shaders/warna_hidung.frag";
        string vert_black = "C:/Users/REPUBLIC OF GAMERS/Documents/grafikom/UTS_Grafkom/GrafKom/GrafKom/Shaders/alis_mata.vert";
        string frag_black = "C:/Users/REPUBLIC OF GAMERS/Documents/grafikom/UTS_Grafkom/GrafKom/GrafKom/Shaders/alis_mata.frag";
        string vert_grey = "C:/Users/REPUBLIC OF GAMERS/Documents/grafikom/UTS_Grafkom/GrafKom/GrafKom/Shaders/warna_mata.vert";
        string frag_grey = "C:/Users/REPUBLIC OF GAMERS/Documents/grafikom/UTS_Grafkom/GrafKom/GrafKom/Shaders/warna_mata.frag";
        public Project_UTS(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) : base(gameWindowSettings, nativeWindowSettings)
        {

        }
       
        protected override void OnLoad()
        {
            // clear background
            GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);
            GL.Enable(EnableCap.DepthTest);
            transform = Matrix4.Identity;
            head1.CreateEllipsoidVertices(0.0f, 0.0f, 0.0f, 0.35f, 0.34f, 0.33f);
            head2.CreateEllipsoidVertices(0.0f, -0.05f, 0.0f, 0.31f, 0.29f, 0.34f);
            nose.createEllipsoid(0.0f, -0.03f, -0.33f, 0.05f, 0.05f, 0.05f);           
            left_eye.CreateEllipsoidVertices(-0.1f, 0.045f, -0.32f, 0.03f, 0.04f, 0.03f);
            left_eye2.CreateEllipsoidVertices(-0.1f, 0.1f, -0.32f, 0.03f, 0.04f, 0.03f);
            right_eye.CreateEllipsoidVertices(0.1f, 0.045f, -0.32f, 0.03f, 0.04f, 0.03f);
            right_eye2.CreateEllipsoidVertices(0.1f, 0.1f, -0.32f, 0.03f, 0.04f, 0.03f);
            necklace.CreateUniqEllipsoidVertices2(0.0f, 0.0f, -0.35f, 0.27f, 0.27f, 0.27f);      
            pocket.CreateHalfEllipsoi(0.0f, -0.30f, 0.5f, 0.15f, 0.05f, 0.15f);         
            left_hand.createEllipsoid(-0.4f, -0.5f, 0.0f, 0.05f, 0.05f, 0.05f);
            right_hand.createEllipsoid(0.4f, -0.5f, 0.0f, 0.05f, 0.05f, 0.05f);
            right_foot.createEllipsoid(0.09f, -0.86f, 0.01f, 0.05f, 0.05f, 0.05f);
            left_foot.createEllipsoid(-0.09f, -0.86f, 0.01f, 0.05f, 0.05f, 0.05f);
            body.createEllipsoid2(0.0f, 0.0f, -0.55f, 0.39f, 0.39f, 0.39f);    
            head1.SetupObject(vert_blue,frag_blue);
            head2.SetupObject(vert_white, frag_white);
            nose.SetupObject(vert_red,frag_red);
            left_eye.SetupObject(vert_grey,frag_grey);
            right_eye.SetupObject(vert_grey, frag_grey);
            left_eye2.SetupObject(vert_black,frag_black);
            right_eye2.SetupObject(vert_black, frag_black);
            necklace.SetupObject(vert_red, frag_red);
            pocket.SetupObject(vert_white, frag_white);
            left_hand.SetupObject(vert_white, frag_white);
            right_hand.SetupObject(vert_white, frag_white);
            right_foot.SetupObject(vert_white, frag_white);
            left_foot.SetupObject(vert_white, frag_white);
            body.SetupObject(vert_blue, frag_blue);
            head1.Scale(0.5f);
            head2.Scale(0.5f);
            nose.Scale(0.5f);
            left_eye.Scale(0.5f);
            right_eye.Scale(0.5f);
            left_eye2.Scale(0.5f);
            right_eye2.Scale(0.5f);
            body.Scale(0.5f);
            left_foot.Scale(0.5f);
            right_foot.Scale(0.5f);
            right_hand.Scale(0.5f);
            left_hand.Scale(0.5f);           
            pocket.Scale(0.5f);
            necklace.Scale(0.5f);

            for (int q = 0; q < 5; q++)
            {
                pocket.Rotate();
            }

            for (int q = 0; q < 13; q++)
            {
                body.Rotate('x');
                if (q == 12)
                {
                    body.Rotate('x', 15f);
                }
            }
            body.Scale();
            //// Setup First Object, Spongebob
            Object3D[0] = new Mesh();
            sponbody.LoadObjectFile(path_body);
            sponbody.SetupObject(vert_body, frag_body);
            sponbody.Translate(-0.44f, 0.0f, 0.0f);
            sponbody.Scale(1.3f);
            mata.LoadObjectFile(path_mata);
            mata.SetupObject(vert_mata, frag_mata);
            mata.Translate(0.0f, 0.0f, 0.0f);          
            dasi.LoadObjectFile(path_dasi);
            dasi.SetupObject(vert_dasi, frag_dasi);
            dasi.Translate(0.0f, 0.0f, -0.01f);
            lenganbaju.LoadObjectFile(path_lenganbaju);
            lenganbaju.SetupObject(vert_lenganbaju, frag_lenganbaju);
            celana.LoadObjectFile(path_celana);
            celana.SetupObject(vert_celana, frag_celana);
            Object3D[0].AddChild(mata);
            Object3D[0].AddChild(lenganbaju);
            Object3D[0].AddChild(dasi);
            Object3D[0].AddChild(celana);
            Object3D[0].Translate(-0.44f, 0.0f, 0.0f);
            Object3D[0].Scale(1.3f);

            //// Setup Second Object, minion

            Object3D[1] = new Mesh();
            badanminion.LoadObjectFile(minion);
            badanminion.SetupObject(vert_mini, frag_mini);
            badanminion.Translate(0.0f, 0.0f, 0.0f);
            kacamata.LoadObjectFile(kacamataminion);
            kacamata.SetupObject(vert_kcmt, frag_kcmt);
            badanminion.Translate(0.6f, 0.0f, 0.0f);
            sepatu.LoadObjectFile(sepatuminion);
            sepatu.SetupObject(vert_sepatu, frag_sepatu);
            kacamata.Translate(-0.09f, -0.03f, -0.33f);
            Object3D[1].AddChild(kacamata);
            Object3D[1].AddChild(sepatu);
            Object3D[1].Translate(0.6f, 0.0f, 0.0f);

            // Setup Third Object, kasur spongebob

            Object3D[2] = new Mesh();
            kasursponge.LoadObjectFile(spongebobed);
            kasursponge.SetupObject(vert_bed, frag_bed);
            tiang.LoadObjectFile(tiangkasur);
            tiang.SetupObject(vert_tiang, frag_tiang);
            tiang.Translate(-0.8f, -0.38f, 0.6f);
            sandaran.LoadObjectFile(sandarankasur);
            sandaran.SetupObject(vert_sandar, frag_sandar);
            sandaran.Translate(-0.8f, -0.38f, 0.17f);
            //Object3D[2].AddChild(tiang);
            //Object3D[2].AddChild(sandaran);
            kasursponge.Translate(-0.685f, -0.4f, 0.0f);
            kasursponge.Scale(1.5f);
            tiang.Scale(1.5f);
            sandaran.Scale(1.5f);
            //lantai
            //Object3D[3] = new Mesh();
            //Object3D[3].LoadObjectFile(lantai1);
            //Object3D[3].SetupObject(vert_lantai, frag_lantai);
            //Object3D[3].Scale(1.6f);
            //Object3D[3].Translate(0.0f, -0.5f, 0.5f);
            //Object3D[0].load();
            //Object3D[1].load();
            //Object3D[2].load();
            //_camera = new Camera(new Vector3(0, 0, 0), Size.X / Size.Y);
            base.OnLoad();

        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            //Object3D[0].Render(_camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            head1.Render();
            head2.Render();
            nose.Render();
            left_eye.Render();
            right_eye.Render();
            left_eye2.Render();
            right_eye2.Render();
            necklace.Render();
            right_foot.Render();
            left_foot.Render();
            body.Render();
            left_hand.Render();
            right_hand.Render();
            sponbody.Render();
            pocket.Render();
            lenganbaju.Render();
            celana.Render();
            dasi.Render();
            mata.Render();
            badanminion.Render();
            kacamata.Render();
            sepatu.Render();
            kasursponge.Render();
            tiang.Render();
            sandaran.Render();
            SwapBuffers();       
            base.OnRenderFrame(args);
        }

        protected override void OnUpdateFrame(FrameEventArgs args)
        {

            KeyboardState input = KeyboardState;
            if (input.IsKeyDown(Keys.W))
            {
                left_foot.Rotate('z', -0.02f);
            }
            if (input.IsKeyDown(Keys.Q))
            {
                left_foot.Rotate('z', 0.02f);
            }
            if (input.IsKeyDown(Keys.E))
            {
                right_foot.Rotate('z', -0.02f);
            }
            if (input.IsKeyDown(Keys.R))
            {
                right_foot.Rotate('z', 0.02f);
            }
            if (input.IsKeyDown(Keys.A))
            {
                left_hand.Rotate('z', 0.02f);             
            }
            if (input.IsKeyDown(Keys.S))
            {
                left_hand.Rotate('z', -0.02f);
            }
            if (input.IsKeyDown(Keys.D))
            {
                right_hand.Rotate('z', 0.02f);
            }
            if (input.IsKeyDown(Keys.F))
            {
                right_hand.Rotate('z', -0.02f);
            }
            
            if (KeyboardState.IsKeyDown(Keys.T))
             {
                    head1.Rotate('y', -0.9f);
                    head2.Rotate('y', -0.9f);
                    nose.Rotate('y', -0.9f);
                    left_eye.Rotate('y', -0.9f);
                    right_eye.Rotate('y', -0.9f);
                    left_eye2.Rotate('y', -0.9f);
                    right_eye2.Rotate('y', -0.9f);          
            }
            if (KeyboardState.IsKeyDown(Keys.Y))
            {
                head1.Rotate('y', 0.9f);
                head2.Rotate('y', 0.9f);
                nose.Rotate('y', 0.9f);
                left_eye.Rotate('y', 0.9f);
                right_eye.Rotate('y', 0.9f);
                left_eye2.Rotate('y', 0.9f);
                right_eye2.Rotate('y', 0.9f);
            }
            if (KeyboardState.IsKeyDown(Keys.U))
            {
                head1.Rotate('x', -0.5f);
                head2.Rotate('x', -0.5f);
                nose.Rotate('x', -0.5f);
                left_eye.Rotate('x', -0.5f);
                right_eye.Rotate('x', -0.5f);
                left_eye2.Rotate('x', -0.5f);
                right_eye2.Rotate('x', -0.5f);
            }
            if (KeyboardState.IsKeyDown(Keys.I))
            {
                head1.Rotate('x', 0.5f);
                head2.Rotate('x', 0.5f);
                nose.Rotate('x', 0.5f);
                left_eye.Rotate('x', 0.5f);
                right_eye.Rotate('x', 0.5f);
                left_eye2.Rotate('x', 0.5f);
                right_eye2.Rotate('x', 0.5f);
            }
             if (KeyboardState.IsKeyDown(Keys.Z))
            {
                sponbody.Rotate('x', 1.0f);
                mata.Rotate('x', 1.0f);
                celana.Rotate('x', 1.0f);
                dasi.Rotate('x', 1.0f);
                lenganbaju.Rotate('x', 1.0f);
                kasursponge.Rotate('y', 0.5f);
                sandaran.Rotate('y', 0.5f);
                tiang.Rotate('y', 0.5f);
            }
            if (KeyboardState.IsKeyDown(Keys.X))
            {
                sponbody.Rotate('x', 1.0f);
                mata.Rotate('x', 1.0f);
                celana.Rotate('x', 1.0f);
                dasi.Rotate('x', 1.0f);
                lenganbaju.Rotate('x', 1.0f);
                kasursponge.Rotate('y', 0.5f);
                sandaran.Rotate('y', 0.5f);
                tiang.Rotate('y', 0.5f);
            }
            if (KeyboardState.IsKeyDown(Keys.C))
            {
                badanminion.Rotate('y', -0.1f);
                kacamata.Rotate('y', -0.1f);
                sepatu.Rotate('y', -0.1f);
            }
            if (KeyboardState.IsKeyDown(Keys.V))
            {
                head1.Rotate('y', -0.1f);
                head2.Rotate('y', -0.1f);
                nose.Rotate('y', -0.1f);
                left_eye.Rotate('y', -0.1f);
                right_eye.Rotate('y', -0.1f);
                left_eye2.Rotate('y', -0.1f);
                right_eye2.Rotate('y', -0.1f);
                body.Rotate('y', -0.1f);
                left_foot.Rotate('y', -0.1f);
                right_hand.Rotate('y', -0.1f);
                left_hand.Rotate('y', -0.1f);
                right_foot.Rotate('y', -0.1f);
                pocket.Rotate('y', -0.1f);
                necklace.Rotate('y', -0.1f);
            }

            base.OnUpdateFrame(args);
        }

        protected override void OnResize(ResizeEventArgs e)
        {
            GL.Viewport(0, 0, Size.X, Size.Y);
            base.OnResize(e);
        }
        
    }
}