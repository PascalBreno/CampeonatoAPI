using System.Collections.Generic;

namespace Service.ViewModel.Base
{
    public class Page<T>
    {
        public int paginacao { get; set; }
        public int tamanhoPagina { get; set; }
        public int qtdPagina { get; set; }
        private List<T> itens { get; set; }
    }
}