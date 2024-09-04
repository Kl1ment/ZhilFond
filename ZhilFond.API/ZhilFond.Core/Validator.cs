namespace ZhilFond.Core
{
    internal class Validator
    {
        public bool IsValid => _isValid;
        public string Error => _error;

        private string _error = string.Empty;
        private bool _isValid = true;

        public Validator IsEarlierCurrentDate(DateTime dateTime)
        {
            if (dateTime > DateTime.Now)
            {
                _isValid = false;
                _error += "The date cannot be later than the current date\n";
            }

            return this;
        }

        public Validator IsPositive(decimal value)
        {
            if (value < 0)
            {
                _isValid = false;
                _error += "The amount cannot be less than 0\n";
            }

            return this;
        }
    }
}
