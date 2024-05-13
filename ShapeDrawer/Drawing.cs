using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using DrawingShape;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class Drawing
    {
        private readonly List<Shape> _shapes;
        private Color _background;
        StreamWriter writer;
        StreamReader reader;

        public Drawing(Color background)
        {
            _shapes = new List<Shape>();
            _background = background;
        }
        public Drawing() : this(Color.White)
        {

        }
        public List<Shape> SelectedShapes
        {
            get
            {
                List<Shape> result = new List<Shape>();
                foreach (Shape s in _shapes)
                {
                    if (s.Selected)
                    {
                        result.Add(s);
                    }
                }
                return result;
            }
        }
        public int ShapeCount
        {
            get { return _shapes.Count; }
        }
        public Color Background
        {
            get { return _background; }
            set { _background = value; }
        }
        public void Draw()
        {
            SplashKit.ClearScreen(_background);
            foreach (Shape s in _shapes)
            {
                s.Draw();
            }
        }
        public void SelectShapesAt(Point2D pt)
        {
            foreach (Shape s in _shapes)
            {
                if (!s.Selected)
                {
                    s.Selected = s.IsAt(pt);
                }
                else
                {
                    s.Selected = !s.IsAt(pt);
                }
            }
        }
        public void AddShape(Shape s)
        {
            _shapes.Add(s);
        }
        public void RemoveShape(Shape s)
        {
            _shapes.Remove(s);
        }
        public void Save(string filename)
        {
            writer = new StreamWriter(filename);
            writer.WriteColor(_background);
            writer.WriteLine(ShapeCount);
            
            try 
            {
                foreach (Shape s in _shapes)
                {
                    s.SaveTo(writer);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            writer.Close();
        }
        public void Load(string filename)
        {
            reader = new StreamReader(filename);
            Shape s;
            string kind;
            Background = reader.ReadColor();
            int count = reader.ReadInteger();
            _shapes.Clear();
            try 
            {
                for (int i = 0; i < count; i++)
                {
                    kind = reader.ReadLine();
                    switch (kind)
                    {
                        case "Rectangle":
                            s = new MyRectangle();
                            break;
                        case "Circle":
                            s = new MyCircle();
                            break;
                        case "Line":
                            s = new MyLine();
                            break;
                        default:
                            throw new InvalidDataException("Error at shape: " + kind);
                    }
                    s.LoadFrom(reader);
                    AddShape(s);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            reader.Close();
        }



    }
}