namespace LearnFrameworkMvc.Module
{
    public static class ConstantString
    {
		//System Message
		public const string DataNotFound = "Data Not Found";
		public const string DataNotFoundWithParam = "{0} Not Found";
		public const string DuplicateData = "Duplicate Data";
		public const string ProcessSuccessfully = "Process Successfully";
		public const string DeleteSuccessfully = "Delete Successfully";
		public const string DeleteFailed = "Delete Failed";

		public const string Forbidden = "Forbidden";
		public const string ThisDataIsUsedInOtherTransaction = "This data is used in other transactions";

		//Custom Attribute
		public const string NoHtmlTagAllowed = "No html tags allowed";
		public const string EnterValueBiggerThan0 = "Please enter a value bigger than 0";
		public const string EnterValueBiggerThanOrEqualsTo0 = "Please enter a value bigger than or equals to 0";
		public const string EnterValueLowerThanOrEqualsTo0 = "Please enter a value lower than or equals to 0";
		public const string NumberIsInvalid = "Number Is Invalid";

		//Validation
		public const string PleaseSetupNationality = "Please setup Nationality Passport Validation first";
		public const string PassengerHasBeenBanned = "This Passenger has been banned";
		public const string AllotmentHasBeenRequested = "{0} Has Been Requested";
		public const string AdjustedAllotmentExceedsRequestedAllotment = "The Adjusted Allotment For {0} Exceeds The Originally Requested Allotment";
		public const string SubmissionPeriodAllotmentHasEnd = "The {0} Submission Period For Allotment Request Has Ended";
		public const string PassengerExpired = "This Passenger passport already expired";

		//Role
		public const string Administrator = "administrator";
		public const string Shop = "shop";
		public const string Member = "member";
	}
}
