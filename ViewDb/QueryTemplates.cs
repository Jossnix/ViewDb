namespace ViewDb;

public static class QueryTemplates
{
    public static string CategoriesAll= "SELECT id, name FROM categories";
    public static string SalesmanAll= "SELECT id, name, phone FROM salesman";
    public static string ProductsAll= "SELECT id, name, category_id, salesman_id, sold FROM products";
}