using Xunit;

public class MaxValueFinderTests
{
    [Fact]
    public void FindMaxValue_WhenCalledWithArrayOfIntegers_ReturnsMaxValue()
    {
        // Arrange (Подготовка данных)
        int[] numbers = { 4, 7, 2, 9, 1, 5 };

        // Act (Действие)
        int result = MaxValueFinder.FindMaxValue(numbers);

        // Assert (Проверка утверждений)
        Assert.Equal(9, result);
    }


    [Fact]
    public void FindMaxValue_EmptyArray()
    {
        int[] numbers = { };
        Assert.Throws<InvalidOperationException>(()=>MaxValueFinder.FindMaxValue(numbers));
    }
}