namespace Project1.Domain.Constants
{
    public static class ValidationConstant
    {
        public const string CellphonePattern = "^09[0-9]{9}$";
        public const string NumericPattern = "^([0-9])*$";
        public const string PhonePattern = "^0[1-9][0-9]{9}$";
        public const string EmailPattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9.-]+$";
        public const string EnglishNumberPattern = "^[0-9]+$";
        public const string BankAccountNumber = "^(?i:IR)(?=.{22}$)[0-9]*$";
    }
}
