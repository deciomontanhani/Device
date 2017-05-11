using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutoWeb.Models
{
    public class ViewModel
    {
        public Cliente cliente { get; set; }
        public Investidor investidor { get; set; }
        public IEnumerable<Noticia> noticia { get; set; }
        public Usuario usuario { get; set; }
        public Pais pais { get; set; }
        public IEnumerable<Estado> estado { get; set; }
        public IEnumerable<Cidade> cidade { get; set; }  
       

    }
}