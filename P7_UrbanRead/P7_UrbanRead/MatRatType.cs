namespace P7_UrbanRead
{
    //Book raiting https://perspectivesonreading.com/national-book-ratings-for-parents/
    //GB just return 2 options - https://googleapis.dev/dotnet/Google.Apis.Books.v1/latest/api/Google.Apis.Books.v1.PersonalizedstreamResource.GetRequest.MaxAllowedMaturityRatingEnum.html 
    //Allow the user to select multiple options.
    enum MatRatType
    {
        mature, 
        nonMature,
        Everyone,
        Child_6to9,
        Teen_9to13,
        Teen_13to17,
        Adult,
        Restricted
    }
}
