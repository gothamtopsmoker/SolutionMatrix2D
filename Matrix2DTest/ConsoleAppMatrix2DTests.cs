using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Matrix2DTest
{
    [TestClass]
    public sealed class ConsoleAppMatrix2DTests
    {
        [TestMethod]
        public void Main_ExecutesBezBledow_WypisujeDaneNaKonsole()
        {
            // Arrange
            var originalOut = Console.Out;
            using var sw = new StringWriter();
            try
            {
                Console.SetOut(sw);

                // Act
                // We call the entry point of the Program via reflection
                var entryPoint = typeof(Program).Assembly.EntryPoint;
                if (entryPoint != null)
                {
                    var parameters = entryPoint.GetParameters().Length == 0 ? null : new object[] { Array.Empty<string>() };
                    entryPoint.Invoke(null, parameters);
                }

                // Assert
                var output = sw.ToString();
                Assert.IsFalse(string.IsNullOrWhiteSpace(output), "Aplikacja konsolowa powinna cokolwiek wypisać na wyjście.");
                Assert.IsTrue(output.Contains("--- Prezentacja możliwości klasy Matrix2D ---"), "Oczekiwano odpowiedniego nagłówka.");
                Assert.IsTrue(output.Contains("m1 + m2 = [[6, 8], [10, 12]]"), "Oczekiwano wyniku dodawania.");
            }
            finally
            {
                // Cleanup
                Console.SetOut(originalOut);
            }
        }
    }
}
