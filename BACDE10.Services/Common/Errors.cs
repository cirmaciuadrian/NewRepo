namespace BACDE10.BusinessLogic.Common;

public static class Errors
{
    public static (string Message, string Code) ErrorTestCuParametru(string parameter) => ($"Eroare de test cu parametru {parameter}", "ErrorTestCuParametru");
    public static (string Message, string Code) ErrorTestFaraParametru => ($"Eroare de test fara parametru", "ErrorTestFaraParametru");

}
