using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Stream_Progress
{
    public class StreamProgressInfo
    {
        private IStreamable streamFile;

        // If we want to stream a music file, we can.
        public StreamProgressInfo(IStreamable streamFile)
        {
            this.streamFile = streamFile;
        }

        public int CalculateCurrentPercent()
        {
            return (this.streamFile.BytesSent * 100) / this.streamFile.Length;
        }
    }
}
