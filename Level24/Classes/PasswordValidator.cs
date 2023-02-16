namespace Classes;

public class PasswordValidator
{
    public static bool IsValid(string password)
    {
        if (password.Length < 6 || password.Length > 13) return false;

        bool containsUppercaseLetter = false;
        bool containsLowercaseLetter = false;
        bool containsNumber = false;
        bool containsCapitalT = false;
        bool containsAmpersand = false;

        foreach(char c in password)
        {
            if (char.IsLower(c)) containsLowercaseLetter = true;
            if (char.IsUpper(c)) containsUppercaseLetter = true;
            if (char.IsDigit(c)) containsNumber= true;
            if (c == 'T') containsCapitalT = true;
            if (c == '&') containsAmpersand = true;
        }

        if (containsUppercaseLetter && containsLowercaseLetter && containsNumber && !containsCapitalT && !containsAmpersand) return true;
        return false;
    }
}
