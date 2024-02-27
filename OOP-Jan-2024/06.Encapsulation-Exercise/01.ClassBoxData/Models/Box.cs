
namespace ClassBoxData.Models
{
    public class Box
    {
        private const string PropertyValueExceptionMessage = "{0} cannot be zero or negative.";

        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get { return this.length; }
            //private set
            //init//Ако го направя така, вече никой не може да го достъпи дори и тук в класа с някой метод
            init
            {
                if (value <= 0)
                { 
                    //throw new ArgumentException("Lenght cannot be zero or negative.");

                    throw new ArgumentException(string.Format(PropertyValueExceptionMessage, nameof(Length)));
                }
                else
                {
                    this.length = value;
                }


            }
        }

        public double Width
        {
            get => width;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(PropertyValueExceptionMessage, nameof(Width)));
                }
                else
                {
                    width = value;
                }
            }
        }

        public double Height
        {
            get => height;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(PropertyValueExceptionMessage, nameof(Height)));
                }
                else
                {
                    height = value;
                }
            }
        }

        //public double SurfaceArea()
        //=> 2 * Length * Width + LateralSurfaceArea();

        public double SurfaceArea()
        {
            return 2 * Length * Width + LateralSurfaceArea();
        }

        public double LateralSurfaceArea()
            => 2 * Length * Height + 2 * Width * Height;

        public double Volume()
            => Length * Width * Height;

    }
}

