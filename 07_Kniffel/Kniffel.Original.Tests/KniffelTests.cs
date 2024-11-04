using Xunit;

namespace Jarai.Refactoring.Kniffel.Original.Tests
{
    public class KniffelTests
    {
        [Fact]
        public void Chance_scores_sum_of_all_dice()
        {
            var expected = 15;
            var actual = Kniffel.Chance(2, 3, 4, 5, 1);
            Assert.Equal(expected, actual);


            Assert.Equal(16, Kniffel.Chance(3, 3, 4, 5, 1));
        }

        [Fact]
        public void Fact_1s()
        {
            Assert.True(Kniffel.Ones(1, 2, 3, 4, 5) == 1);
            Assert.Equal(2, Kniffel.Ones(1, 2, 1, 4, 5));
            Assert.Equal(0, Kniffel.Ones(6, 2, 2, 4, 5));
            Assert.Equal(4, Kniffel.Ones(1, 2, 1, 1, 1));
        }

        [Fact]
        public void Fact_2s()
        {
            Assert.Equal(4, Kniffel.Twos(1, 2, 3, 2, 6));
            Assert.Equal(10, Kniffel.Twos(2, 2, 2, 2, 2));
        }

        [Fact]
        public void Fact_threes()
        {
            Assert.Equal(6, Kniffel.Threes(1, 2, 3, 2, 3));
            Assert.Equal(12, Kniffel.Threes(2, 3, 3, 3, 3));
        }

        [Fact]
        public void fives()
        {
            Assert.Equal(10, new Kniffel(4, 4, 4, 5, 5).Fives());
            Assert.Equal(15, new Kniffel(4, 4, 5, 5, 5).Fives());
            Assert.Equal(20, new Kniffel(4, 5, 5, 5, 5).Fives());
        }

        [Fact]
        public void four_of_a_knd()
        {
            Assert.Equal(12, Kniffel.FourOfAKind(3, 3, 3, 3, 5));
            Assert.Equal(20, Kniffel.FourOfAKind(5, 5, 5, 4, 5));
            Assert.Equal(12, Kniffel.FourOfAKind(3, 3, 3, 3, 3));
        }

        [Fact]
        public void fours_Fact()
        {
            Assert.Equal(12, new Kniffel(4, 4, 4, 5, 5).Fours());
            Assert.Equal(8, new Kniffel(4, 4, 5, 5, 5).Fours());
            Assert.Equal(4, new Kniffel(4, 5, 5, 5, 5).Fours());
        }

        [Fact]
        public void fullHouse()
        {
            Assert.Equal(18, Kniffel.FullHouse(6, 2, 2, 2, 6));
            Assert.Equal(0, Kniffel.FullHouse(2, 3, 4, 5, 6));
        }

        [Fact]
        public void largeStraight()
        {
            Assert.Equal(20, Kniffel.LargeStraight(6, 2, 3, 4, 5));
            Assert.Equal(20, Kniffel.LargeStraight(2, 3, 4, 5, 6));
            Assert.Equal(0, Kniffel.LargeStraight(1, 2, 2, 4, 5));
        }

        [Fact]
        public void one_pair()
        {
            Assert.Equal(6, Kniffel.ScorePair(3, 4, 3, 5, 6));
            Assert.Equal(10, Kniffel.ScorePair(5, 3, 3, 3, 5));
            Assert.Equal(12, Kniffel.ScorePair(5, 3, 6, 6, 5));
        }

        [Fact]
        public void sixes_Fact()
        {
            Assert.Equal(0, new Kniffel(4, 4, 4, 5, 5).sixes());
            Assert.Equal(6, new Kniffel(4, 4, 6, 5, 5).sixes());
            Assert.Equal(18, new Kniffel(6, 5, 6, 6, 5).sixes());
        }

        [Fact]
        public void smallStraight()
        {
            Assert.Equal(15, Kniffel.SmallStraight(1, 2, 3, 4, 5));
            Assert.Equal(15, Kniffel.SmallStraight(2, 3, 4, 5, 1));
            Assert.Equal(0, Kniffel.SmallStraight(1, 2, 2, 4, 5));
        }

        [Fact]
        public void three_of_a_kind()
        {
            Assert.Equal(9, Kniffel.ThreeOfAKind(3, 3, 3, 4, 5));
            Assert.Equal(15, Kniffel.ThreeOfAKind(5, 3, 5, 4, 5));
            Assert.Equal(9, Kniffel.ThreeOfAKind(3, 3, 3, 3, 5));
        }

        [Fact]
        public void two_Pair()
        {
            Assert.Equal(16, Kniffel.TwoPair(3, 3, 5, 4, 5));
            Assert.Equal(16, Kniffel.TwoPair(3, 3, 5, 5, 5));
        }

        [Fact]
        public void Yatzy_scores_50()
        {
            var expected = 50;
            var actual = Kniffel.yatzy(4, 4, 4, 4, 4);
            Assert.Equal(expected, actual);
            Assert.Equal(50, Kniffel.yatzy(6, 6, 6, 6, 6));
            Assert.Equal(0, Kniffel.yatzy(6, 6, 6, 6, 3));
        }
    }
}