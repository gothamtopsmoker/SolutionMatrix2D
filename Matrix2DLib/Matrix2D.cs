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

        public static Matrix2D Id { get; } = new Matrix2D();
public static Matrix2D Zero { get; } = new Matrix2D(0, 0, 0, 0);

        public override string ToString() => $"[[{a}, {b}], [{c}, {d}]]";

        public static Matrix2D Parse(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) throw new FormatException();

            var match = System.Text.RegularExpressions.Regex.Match(s.Trim(), @"^\[?\s*\[\s*(-?\d+)\s*,\s*(-?\d+)\s*\]\s*,\s*\[\s*(-?\d+)\s*,\s*(-?\d+)\s*\]\s*\]?$");
            if (!match.Success) throw new FormatException();

            int a = int.Parse(match.Groups[1].Value);
            int b = int.Parse(match.Groups[2].Value);
            int c = int.Parse(match.Groups[3].Value);
            int d = int.Parse(match.Groups[4].Value);

            return new Matrix2D(a, b, c, d);
        }


        #region rownosc
        public bool Equals(Matrix2D? other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (other is null) return false;
            return a == other.a && b == other.b && c == other.c && d == other.d;
        }

        public override bool Equals(object? obj) => obj is Matrix2D m && Equals(m);

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

        public static Matrix2D operator -(Matrix2D m) => -1 * m;
        #endregion

        #region inne operacje
        public static Matrix2D Transpose(Matrix2D matrix) => new Matrix2D(matrix.a, matrix.c, matrix.b, matrix.d);
        public Matrix2D Transpose() => Transpose(this);

        public static int Determinant(Matrix2D matrix) => matrix.a * matrix.d - matrix.b * matrix.c;
        public int Det() => Determinant(this);
        #endregion

        #region rzutowania
        public static explicit operator int[,](Matrix2D m) => new int[,] { { m.a, m.b }, { m.c, m.d } };
        #endregion
    }
}
