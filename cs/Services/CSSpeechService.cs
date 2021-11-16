 public class CSSpeechService
    {
        public CSSpeechService()
        {

        }
        public async Task<string> SynthesisToSpeakerAsync(string text)
        {
            // Creates an instance of a speech config with specified subscription key and service region.
            // Replace with your own subscription key and service region (e.g., "westus").
            var config = SpeechConfig.FromSubscription(KEYS.Key1, KEYS.Region);

            // Creates a speech synthesizer using the default speaker as audio output.
            using (var synthesizer = new SpeechSynthesizer(config))
            {

                using (var result = await synthesizer.SpeakTextAsync(text))
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    if (result.Reason == ResultReason.SynthesizingAudioCompleted)
                    {
                        //Console.WriteLine($"Speech synthesized to speaker for text [{text}]");
                        stringBuilder.Append("Succes");
                    }
                    else if (result.Reason == ResultReason.Canceled)
                    {
                        var cancellation = SpeechSynthesisCancellationDetails.FromResult(result);   
                        stringBuilder.AppendLine($"CANCELED: Reason ={ cancellation.Reason} ");
                        stringBuilder.AppendLine($"CANCELED: ErrorCode={cancellation.ErrorCode}");
                        stringBuilder.AppendLine($"CANCELED: ErrorDetails=[{cancellation.ErrorDetails}]");
                        stringBuilder.AppendLine($"CANCELED: Did you update the subscription info?");
                                     
                    }

                    return stringBuilder.ToString();
                }
            }
        }
    }