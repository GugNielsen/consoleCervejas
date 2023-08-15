using System;
using System.Collections.Generic;

namespace Prototipo_Cervejaria.ModelelosImplementados
{
    public class Produto
    {
        #region Propriedades  de  produtos 
        public int Cod { get; set; }
        public string Cerveja_Name { get; set; }
        public double Valor { get; set; }
        #endregion

     /// <summary>
     /// Construtor da Classe 
     /// </summary>
        public Produto()
        {
         

        }

        /// <summary>
        /// Sobreescrevendo a String para ler o Melhor 
        /// </summary>
        /// <returns></returns>
       public override string ToString()
        {
            return ("Código: " + Cod + "\r\n"
                + "Cerveja: " + Cerveja_Name + "\r\n"+
                "Valor : " + Valor + "\r\n"+ "------------------------------"); 
        } 
    }
}
