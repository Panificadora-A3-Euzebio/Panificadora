using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panificadora
{
    internal class produto
    {
        public int id;
        public String nome;
        public String undDeVenda;
        public int quantidade;

        public produto( String nome, String undDeVenda, int quantidade)
        {
            this.nome = nome;
            this.nome = undDeVenda;
            this.undDeVenda = undDeVenda;
            
        }

    }
}
