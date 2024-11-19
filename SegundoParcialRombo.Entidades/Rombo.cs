
namespace SegundoParcialRombo.Entidades
{
    public class Rombo
    {
        private double lado;
        private double perimetro;
        private int area;

        public int DiagonalMayor { get; set; }
        public int DiagonalMenor { get; set; }
        public Contorno TipoContorno { get; set; }
        public Rombo()
        {

        }
        public Rombo(int diagonalMayor, int diagonalMenor, Contorno tipoContorno)
        {
            if (diagonalMayor <= 0 || diagonalMenor <= 0)
            {
                throw new ArgumentException("Las diagonales deben ser mayores que cero.");
            }

            DiagonalMayor = diagonalMayor;
            DiagonalMenor = diagonalMenor;
            TipoContorno = tipoContorno;
        }
        public double CalcularLado()
        {
            return lado = Math.Sqrt(Math.Pow(DiagonalMayor / 2, 2) + Math.Pow(DiagonalMenor / 2, 2));
        }
        public double CalcularPerimetro()
        {
            return perimetro = 4 * lado;
        }
        public double CalcularArea()
        {
            return area = (DiagonalMayor * DiagonalMenor) / 2;
        }

    }
}