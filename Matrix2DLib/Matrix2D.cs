namespace Matrix2DLib
{

   
    //macierz jest niezmiennicza
    // reprezentacja za pomoca 4 zmiennych int a,b,c,d
    // |a b|
    // |c d|
    public class Matrix2D: IEquatable<Matrix2D>
    {
        private readonly int a, b, c, d;
    
        public Matrix2D(int a, int b, int c, int d)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;
        }

        public Matrix2D() : this(1, 0, 0, 1) { }
        
        public static Matrix2D Id => new Matrix2D();
        public static Matrix2D Zero => new Matrix2D(0, 0, 0, 0);

        public override string ToString() => $"[[{a}, {b}], [{c}, {d}]]";


        #region rownosc
        public bool Equals(Matrix2D? other)
        {
            if (other is null) return false;
            return a == other.a && b == other.b && c == other.c && d == other.d;
        }
        override public bool Equals(object? obj)
        {
            if (obj is null) return false;
            return obj is Matrix2D m && Equals(m);
        }
        public override int GetHashCode() => HashCode.Combine(a, b, c, d);

        public static bool operator ==(Matrix2D? left, Matrix2D? right)
        {
            if (left is null) return right is null;
            return left.Equals(right);
        }
        public static bool operator !=(Matrix2D? left, Matrix2D? right) => !(left == right);
        #endregion

        #region operacje arytmetyczne
        public static Matrix2D operator +(Matrix2D left, Matrix2D right) =>
            new Matrix2D(left.a + right.a, left.b + right.b, left.c + right.c, left.d + right.d);

        public static Matrix2D operator -(Matrix2D left, Matrix2D right) =>
            new Matrix2D(left.a - right.a, left.b - right.b, left.c - right.c, left.d - right.d);

        public static Matrix2D operator *(Matrix2D left, Matrix2D right) =>
            new Matrix2D(
                left.a * right.a + left.b * right.c, left.a * right.b + left.b * right.d,
                left.c * right.a + left.d * right.c, left.c * right.b + left.d * right.d
            );

        public static Matrix2D operator *(int k, Matrix2D m) =>
            new Matrix2D(k * m.a, k * m.b, k * m.c, k * m.d);

        public static Matrix2D operator *(Matrix2D m, int k) =>
            new Matrix2D(m.a * k, m.b * k, m.c * k, m.d * k);

        public static Matrix2D operator -(Matrix2D m) =>
            new Matrix2D(-m.a, -m.b, -m.c, -m.d);
        #endregion

        // wymyslec testy na sprawdzenie Equals
    }
}
