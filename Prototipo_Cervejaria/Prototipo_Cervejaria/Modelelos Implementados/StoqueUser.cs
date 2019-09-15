using System;
using System.Collections.Generic;

namespace Prototipo_Cervejaria.ModelelosImplementados
{
    // StoqueUser Herda de Produto 
    public class StoqueUser: Produto
    {
        // Todas as Propriedades de Produtos são de Stoque
        // Nem todas propeirade de StoqueUser `são de produtos 
        #region Propriedade Esclusivas de StoqueUser
        public int Quantidade { get; set; }
        public double ValorTotal_Stoque { get; set; }
        #endregion
     
        public StoqueUser()
        {
        }

        // Sobreescrevendo o a To String 
        public override string ToString()
        {
            return ("Código: " + cod + "\r\n"
                + "Cerveja: " + Cerveja_Name + "\r\n"
                + "Quantidade : " + Quantidade + "\r\n" +
                "Valor  Total: " + ValorTotal_Stoque + "\r\n" +
                "------------------------------");
        }
    }
}
