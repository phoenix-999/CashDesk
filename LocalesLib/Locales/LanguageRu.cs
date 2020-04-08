using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageLib.Locales
{
    [Serializable]
    class LanguageRu : ILanguage
    {
        private Dictionary<StrResourceKeys, string> _resources;

        public LanguageRu()
        {
            _resources = new Dictionary<StrResourceKeys, string>();
        }
        public string this[StrResourceKeys key]
        {
            get
            {
                return _resources[key];
            }
        }

        public string LanguageName { get => "ru"; }

        public  void Initialize()
        {
            _resources[StrResourceKeys.DbException] = "Ошибка в работе с базой данных. Обратитесь к администратору.";
            _resources[StrResourceKeys.InputDataException] = "Ошибка обработки данных";
            _resources[StrResourceKeys.CashDesc] = "Касса";
            _resources[StrResourceKeys.Goods] = "Товары";
            _resources[StrResourceKeys.Product] = "Товар";
            _resources[StrResourceKeys.Accounts] = "Счета";
            _resources[StrResourceKeys.Filter] = "Фильтр";
            _resources[StrResourceKeys.ProductName] = "Название товара";
            _resources[StrResourceKeys.ProductType] = "Тип товара";
            _resources[StrResourceKeys.Price] = "Цена";
            _resources[StrResourceKeys.Description] = "Расшифровка";
            _resources[StrResourceKeys.Error] = "Ошибка";
            _resources[StrResourceKeys.Search] = "Поиск";
            _resources[StrResourceKeys.Add] = "Добавить";
            _resources[StrResourceKeys.Apply] = "Применить";
            _resources[StrResourceKeys.Cancel] = "Отмена";
            _resources[StrResourceKeys.ConcurencyException] = "Одна или несколько строк были изменены другим пользователем";
            _resources[StrResourceKeys.ConcurencyExceptionQuestion] = "Продолжить обновление не изменных строк?";
            _resources[StrResourceKeys.DeleteQuestion] = "Вы действительно хотите удалить выбранные элементы?";
            _resources[StrResourceKeys.DeleteConfirmed] = "Подтверждение удаления";
            _resources[StrResourceKeys.AccountNumber] = "Номер счета";
            _resources[StrResourceKeys.AccountDate] = "Дата счета";
            _resources[StrResourceKeys.Amount] = "Сумма";
            _resources[StrResourceKeys.Discount] = "Скидка";
        }
    }
}
