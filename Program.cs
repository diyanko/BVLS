/*
 * Will have to install the following
 *  - NAG Library
 *  - MathNet.Numerics
 */

using System;
using NagLibrary;
using System.IO;
using System.Linq;
using MathNet.Numerics.Data.Text;
using MathNet.Numerics.LinearAlgebra;

namespace NNLS
{
    class Program
    {
        static void Main(string[] args)
        {
            int itype = 1;
            int m = 1215; // Number of points
            int n = 424; // Number of lights
            int lda = m;
            double tol = 0.0;
            double[] x = new double[n];
            double rnorm = 0.0;
            int nfree = 0;
            double[] w = new double[n];
            int[] indx = new int[n];
            int ifail = 0;

            // Path to the A matrix
            string a_path = "C:/Users/Diyanko/Desktop/NNLS/bin/x64/Release/net5.0/Matrix.csv";
            double[,] a = DelimitedReader.Read<double>(a_path, false, ",", false).Transpose().ToArray();

            // Path to the b matrix
            string b_path = "C:/Users/Diyanko/Desktop/NNLS/bin/x64/Release/net5.0/input_Table@400_Ambient@50.csv";
            double[] b = DelimitedReader.Read<double>(b_path, false, ",", false).Column(0).ToArray();

            // Path to the lower bound matrix
            string bl_path = "C:/Users/Diyanko/Desktop/NNLS/bin/x64/Release/net5.0/bl.csv";
            double[] bl = DelimitedReader.Read<double>(bl_path, false, ",", false).Column(0).ToArray();

            // Path to the upper bound matrix
            string bu_path = "C:/Users/Diyanko/Desktop/NNLS/bin/x64/Release/net5.0/bu.csv";
            double[] bu = DelimitedReader.Read<double>(bu_path, false, ",", false).Column(0).ToArray();

            nag_declarations.E04PCF(ref itype, ref m, ref n, a, ref lda, b, bl, bu, ref tol, x, ref rnorm, ref nfree, w, indx, ref ifail);

            foreach (var item in x)
                Console.WriteLine(item); // Printing the values of x
            Console.WriteLine("---");
            
            Console.WriteLine("ifail is " + ifail + ". Residual - " + rnorm + ". nfree is " + nfree);
        }
    }
}