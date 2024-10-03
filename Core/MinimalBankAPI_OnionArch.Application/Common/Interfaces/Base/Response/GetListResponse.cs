using MinimalBankAPI_OnionArch.Persistance.Repositories.Base.Pagination;

namespace MinimalBankAPI_OnionArch.Persistance.Repositories.Base.Response
{
    public class GetListResponse<T> : BasePageableModel
    {
        public IList<T> Items
        {
            get => _items ??= new List<T>();
            set => _items = value;
        }

        private IList<T>? _items;
    }
}
