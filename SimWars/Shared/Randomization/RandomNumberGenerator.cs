namespace SimWars.Shared.Randomization; 
public class RandomNumberGenerator {
	private Random _randomNumberGenerator = new Random(); 
	public int GetRandomNumber(int maxNumber) {
		return _randomNumberGenerator.Next(maxNumber) + 1;
	}
}
