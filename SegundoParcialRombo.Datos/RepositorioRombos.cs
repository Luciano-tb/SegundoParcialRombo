using SegundoParcialRombo.Entidades;

namespace SegundoParcialRombo.Datos
{
    public class RepositorioRombos : RepositorioRombosBase1
    {
        private List<Rombo> rombos;
        private string? nombreArchivo = "Rombos.txt";
        private string? rutaProyecto = Environment.CurrentDirectory;
        private string? rutaCompletaArchivo;
        private object contornoSeleccionado;

        public RepositorioRombos()
        {
            rombos = LeerDatos(GetRombos());

        }

        public void AgregarRombo(Rombo rombo)
        {
            rombos.Add(rombo);
        }

        public void EliminarRombo(Rombo rombo)
        {
            rombos.Remove(rombo);
        }

        public bool Existe(Rombo rombo)
        {
            return rombos.Any(e => e.DiagonalMenor == rombo.DiagonalMenor &&
                e.DiagonalMayor == rombo.DiagonalMayor);
        }

        public List<Rombo>? Filtrar(Contorno contornoSeleccionado)
        {
            return rombos.Where(e => e.TipoContorno == contornoSeleccionado).ToList();
        }

        public int GetCantidad(Contorno? contornoSeleccionado = null)
        {
            if (contornoSeleccionado == null)
                return rombos.Count;
            return rombos.Count(e => e.TipoContorno == contornoSeleccionado);
        }

        public List<Rombo> ObtenerRombo()
        {
            return new List<Rombo>(rombos);
        }

        public List<Rombo>? OrdenarAsc()
        {
            return rombos.OrderBy(e => e.CalcularArea()).ToList();
        }

        public List<Rombo>? OrdenarDesc()
        {
            return rombos.OrderByDescending(e => e.CalcularArea()).ToList();
        }

        public bool Existe(int sM, int sm)
        {
            return rombos.Any(e => e.DiagonalMayor == sM &&
            e.DiagonalMenor == sm);
        }

        public void GuardarDatos()
        {
            rutaCompletaArchivo = Path.Combine(rutaProyecto, nombreArchivo);
            using (var escritor = new StreamWriter(rutaCompletaArchivo))
            {
                foreach (var rombo in rombos)
                {
                    string linea = ConstruirLinea(rombo);
                    escritor.WriteLine(linea);
                }
            }
        }

        private string ConstruirLinea(Rombo rombo)
        {
            return $"{rombo.DiagonalMayor}|{rombo.DiagonalMenor}|{rombo.TipoContorno.GetHashCode()}";
        }

        private List<Rombo> GetRombos()
        {
            return rombos;
        }

        private List<Rombo> LeerDatos(List<Rombo> rombos)
        {
            var listaRombos = new List<Rombo>();
            rutaCompletaArchivo = Path.Combine(rutaProyecto, nombreArchivo);
            if (!File.Exists(rutaCompletaArchivo))
            {
                return listaRombos;
            }
            using (var lector = new StreamReader(rutaCompletaArchivo))
            {
                while (!lector.EndOfStream)
                {
                    string? linea = lector.ReadLine();
                    Rombo? rombo = ConstruirRombo(linea);
                    listaRombos.Add(rombo);
                }
            }
            return listaRombos;
        }

        private static Rombo? ConstruirRombo(string? linea)
        {
            var campos = linea!.Split('|');
            var sM = int.Parse(campos[0]);
            var sm = int.Parse(campos[1]);
            var tipoContorno = (Contorno)int.Parse(campos[2]);

        }
    }
}