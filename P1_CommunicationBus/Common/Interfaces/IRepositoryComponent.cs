using System.Xml;

namespace Common.Interfaces
{
    public interface IRepositoryComponent
    {
        XmlDocument SqlQuery(string sql);
    }
}