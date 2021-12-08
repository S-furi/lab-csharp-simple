using System;

namespace ComplexAlgebra
{
    /// <summary>
    /// A type for representing Complex numbers.
    /// </summary>
    ///
    /// TODO: Model Complex numbers in an object-oriented way and implement this class.
    /// TODO: In other words, you must provide a means for:
    /// TODO: * instantiating complex numbers
    /// TODO: * accessing a complex number's real, and imaginary parts
    /// TODO: * accessing a complex number's modulus, and phase
    /// TODO: * complementing a complex number
    /// TODO: * summing up or subtracting two complex numbers
    /// TODO: * representing a complex number as a string or the form Re +/- iIm
    /// TODO:     - e.g. via the ToString() method
    /// TODO: * checking whether two complex numbers are equal or not
    /// TODO:     - e.g. via the Equals(object) method
    public class Complex
    {
        private int _re;
        private int _im;

        public Complex(int re, int im)
        {
            _re = re;
            _im = im;
        }
        
        public int Real => _re;
        public int Imaginary => _im;

        public Complex Plus(Complex b) => new Complex(_re + b._re, _im + b._im);
        public  Complex Complement() => new Complex(_re, -1 * _im);
        public Complex Minus(Complex b) => new Complex(_re - b._re, _im - b._im);
        public double Modulus => Math.Sqrt( Math.Pow(_re, 2) + Math.Pow(_im, 2) );
        public double Phase => Math.Atan2(Real, Imaginary);

        public override string ToString()
        {
            return String.Format("{0}{1}{2}", _re == 0 ? "" : _re.ToString(),
                _im <= 0 ? "" : "+",
                _im == 0 ? "" : (_im == 1 ? "i" : (_im == -1 ? "-i" : _im.ToString() + "i"))
            );
        }

        protected bool Equals(Complex other)
        {
            return _re == other._re && _im == other._im;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Complex) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_re, _im);
        }
    }
}