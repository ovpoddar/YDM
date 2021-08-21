using System;
using System.Collections.Generic;
using System.Linq;

namespace YDM.Concept
{
    public class YDMQueueDownloadProcesser
    {
        private const int _maxDownload = 2;

        public Dictionary<int, YDMDownloader> _queue;

        public YDMQueueDownloadProcesser() =>
            _queue = new Dictionary<int, YDMDownloader>();


        #region Methods
        public void Add(YDMDownloader downloader)
        {
            _queue.Add(_queue.Count, downloader);
        }

        public void Add(List<YDMDownloader> downloader)
        {
            var i = 0;
            while (i < downloader.Count)
            {
                _queue.Add(_queue.Count, downloader[i]);
                i++;
            }
        }

        public void Start(int index)
        {
            var downloding = _queue.Values.Count(a => a.DownloadState == Models.DownloadState.Downloading);
            if (downloding <= _maxDownload)
                _queue[index].Start();
            else
                throw new Exception($"cant download more than {_maxDownload}");
        }

        public void Start()
        {
            for (int i = 0; i < _queue.Count; i++)
            {
                if (i < _maxDownload)
                    _queue[i].Start();
                else
                    _queue[i].Pause();
            }
        }

        public void Pause(int index)
        {
            _queue[index].Pause();
            for (int i = 0; i < _queue.Count; i++)
            {
                if (i < _maxDownload)
                    if (i != index)
                        _queue[i].Start();
                _queue[i].Pause();
            }
        }

        public void Pause()
        {
            for (int i = 0; i < _queue.Count; i++)
            {
                _queue[i].Pause();
            }
        }

        public void Resume(int index)
        {
            _queue[index].Resume();
        }

        public void Delete(int index)
        {
            _queue[index].Stop();
            _queue.Remove(index);
        }
        #endregion
    }
}
