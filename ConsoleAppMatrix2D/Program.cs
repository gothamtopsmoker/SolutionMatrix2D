using System;
using Matrix2DLib;

Console.WriteLine("--- Prezentacja możliwości klasy Matrix2D ---");

Console.WriteLine("\n1. Tworzenie macierzy:");
var m1 = new Matrix2D(1, 2, 3, 4);
var m2 = new Matrix2D(5, 6, 7, 8);
Console.WriteLine($"m1 = {m1}");
Console.WriteLine($"m2 = {m2}");

Console.WriteLine("\n2. Wbudowane typy (zero i identyczność):");
Console.WriteLine($"Matrix2D.Zero = {Matrix2D.Zero}");
Console.WriteLine($"Matrix2D.Id = {Matrix2D.Id}");

Console.WriteLine("\n3. Operacje arytmetyczne:");
Console.WriteLine($"m1 + m2 = {m1 + m2}");
Console.WriteLine($"m1 - m2 = {m1 - m2}");
Console.WriteLine($"m1 * m2 = {m1 * m2}");
Console.WriteLine($"3 * m1 = {3 * m1}");
Console.WriteLine($"m1 * 3 = {m1 * 3}");
Console.WriteLine($"-m1 = {-m1}");

Console.WriteLine("\n4. Transpozycja:");
Console.WriteLine($"Transpozycja statyczna: Matrix2D.Transpose(m1) = {Matrix2D.Transpose(m1)}");
Console.WriteLine($"Transpozycja z obiektu: m1.Transpose() = {m1.Transpose()}");

Console.WriteLine("\n5. Wyznacznik:");
Console.WriteLine($"Wyznacznik statyczny: Matrix2D.Determinant(m1) = {Matrix2D.Determinant(m1)}");
Console.WriteLine($"Wyznacznik z obiektu: m1.Det() = {m1.Det()}");

Console.WriteLine("\n6. Porównania (operator ==, !=, Equals):");
var m3 = new Matrix2D(1, 2, 3, 4);
Console.WriteLine($"m1 == m3: {m1 == m3}");
Console.WriteLine($"m1 != m2: {m1 != m2}");
Console.WriteLine($"m1.Equals(m3): {m1.Equals(m3)}");

Console.WriteLine("\n7. Rzutowanie jawne do int[,]:");
int[,] array2D = (int[,])m1;
Console.WriteLine($"[ {array2D[0,0]}, {array2D[0,1]} ]");
Console.WriteLine($"[ {array2D[1,0]}, {array2D[1,1]} ]");

Console.WriteLine("\n8. Parsowanie ze string do Matrix2D:");
string text = "[[10, 20], [30, 40]]";
var parsed = Matrix2D.Parse(text);
Console.WriteLine($"Tekst '{text}' sparsowany jako macierz: {parsed}");
