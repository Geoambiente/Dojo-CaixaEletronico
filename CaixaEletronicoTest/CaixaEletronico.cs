using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaixaEletronicoTest
{
    public static class CaixaEletronico
    {
        public static bool VerificarPossibilidadeDeSaque(double valor)
        {
            return (valor % 10) == 0;
        }

        public static int[] EfetuarSaque(int valor)
        {
            if (!VerificarPossibilidadeDeSaque(valor))
                throw new SaqueException("Valor inválido para saque");

            var saque = new List<int>();
            int restante;

            saque.AddRange(SacarValor(out restante, valor, 100));
            saque.AddRange(SacarValor(out restante, restante, 50));
            saque.AddRange(SacarValor(out restante, restante, 20));
            saque.AddRange(SacarValor(out restante, restante, 10));

            return saque.ToArray();
        }

        private static IEnumerable<int> SacarValor(out int restante, int valor, int nota)
        {
            restante = valor;
            var notas = new List<int>();
            if (restante == 0) return notas;
            if (VerificarDivisivel(valor, nota))
            {
                var qtdNotas = new int[valor / nota];
                for (int i = 0; i < qtdNotas.Length; i++)
                {
                    restante -= nota;
                    notas.Add(nota);
                }
            }
            return notas;
        }

        internal static bool VerificarDivisivel(int dividendo, int divisor)
        {
            return dividendo / divisor > 0;
        }
    }
}
