using System;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Threading;

namespace _6._2_3_Inheritance__abstract_classes__interfaces
{
    public class LoadingBarStream : Stream
    {
        private readonly Stream _stream;
        private int _totalBytes;
        private byte[] _buffer;

        public LoadingBarStream(Stream stream)
        {
            _stream = stream;
        }

        class LoadingBarWindow : Window
        {
            private readonly ProgressBar _progressBar;
            private readonly LoadingBarStream _loadingBarStream;
            private CancellationTokenSource cancelTokenSource;
            private CancellationToken token;

            public LoadingBarWindow(LoadingBarStream loadingBarStream)
            {
                _progressBar = new ProgressBar()
                {
                    Height = 100
                };
                Button button = new Button()
                {
                    Content = "Отменить",
                    FontSize = 20,
                };
                Grid grid = new Grid();
                grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(0.7, GridUnitType.Star) });
                grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(0.3, GridUnitType.Star) });
                grid.ColumnDefinitions.Add(new ColumnDefinition());
                grid.ColumnDefinitions.Add(new ColumnDefinition());
                grid.ColumnDefinitions.Add(new ColumnDefinition());
                Grid.SetRow(_progressBar, 0);
                Grid.SetRow(button, 1);
                Grid.SetColumn(_progressBar, 0);
                Grid.SetColumn(button, 1);
                Grid.SetColumnSpan(_progressBar, 3);
                _ = grid.Children.Add(_progressBar);
                _ = grid.Children.Add(button);
                Content = grid;
                Width = 500;
                SizeToContent = SizeToContent.Height;
                ResizeMode = ResizeMode.CanMinimize;
                WindowState = WindowState.Normal;
                Title = "Прогресс загрузки данных";
                Loaded += LoadingBarWindow_Loaded;
                button.Click += Button_Click;
                Closing += LoadingBarWindow_Closing;
                _loadingBarStream = loadingBarStream;
            }

            private void LoadingBarWindow_Closing(object sender, CancelEventArgs e)
            {
                cancelTokenSource.Cancel();
            }

            private void LoadingBarWindow_Loaded(object sender, RoutedEventArgs e)
            {
                cancelTokenSource = new CancellationTokenSource();
                token = cancelTokenSource.Token;
                Task task = new Task(() => ReadInProgres(token));
                _ = task.ContinueWith((task) => Close(), TaskScheduler.FromCurrentSynchronizationContext());
                task.Start();
            }

            private void Button_Click(object sender, RoutedEventArgs e)
            {
                cancelTokenSource.Cancel();
            }

            public void ReadInProgres(CancellationToken token)
            {
                int totalBytes = 0;
                int currentBlockSize = 0;
                int readPosition = 0;
                do
                {
                    if (token.IsCancellationRequested)
                    {
                        _ = MessageBox.Show("Операция отменена!");
                        _loadingBarStream._totalBytes = totalBytes;
                        return;
                    }
                    readPosition = _loadingBarStream._stream.Length - totalBytes < 1024 ? (int)(_loadingBarStream._stream.Length - totalBytes) : 1024;
                    currentBlockSize = _loadingBarStream._stream.Read(_loadingBarStream._buffer, totalBytes, readPosition);
                    totalBytes += currentBlockSize;
                    int percentage = totalBytes * 100 / (int)_loadingBarStream._stream.Length;
                    _ = Dispatcher.BeginInvoke(() => _progressBar.Value = percentage);
                    Thread.Sleep(100);
                } while (currentBlockSize > 0);
                _loadingBarStream._totalBytes = totalBytes;
            }
        }

        public override bool CanRead => _stream.CanRead;

        public override bool CanSeek => _stream.CanSeek;

        public override bool CanTimeout => _stream.CanTimeout;

        public override bool CanWrite => _stream.CanWrite;

        public override long Length => _stream.Length;

        public override long Position
        {
            get => _stream.Position;
            set => _stream.Position = value;
        }

        public override int ReadTimeout { get => _stream.ReadTimeout; set => _stream.ReadTimeout = value; }
        
        public override int WriteTimeout { get => _stream.WriteTimeout; set => _stream.WriteTimeout = value; }

        public override int Read(byte[] buffer, int offset, int count)
        {
            _buffer = buffer;
            LoadingBarWindow loadingBarWindow = new LoadingBarWindow(this);
            _ = loadingBarWindow.ShowDialog();
            return _totalBytes;
        }

        public override IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
        {
            return _stream.BeginRead(buffer, offset, count, callback, state);
        }

        public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
        {
            return _stream.BeginWrite(buffer, offset, count, callback, state);
        }

        public override void Close()
        {
            _stream.Close();
        }

        public override void CopyTo(Stream destination, int bufferSize)
        {
            _stream.CopyTo(destination, bufferSize);
        }

        public override Task CopyToAsync(Stream destination, int bufferSize, CancellationToken cancellationToken)
        {
            return _stream.CopyToAsync(destination, bufferSize, cancellationToken);
        }

        public override ValueTask DisposeAsync()
        {
            return _stream.DisposeAsync();
        }

        public override int EndRead(IAsyncResult asyncResult)
        {
            return _stream.EndRead(asyncResult);
        }

        public override void EndWrite(IAsyncResult asyncResult)
        {
            _stream.EndWrite(asyncResult);
        }

        public override bool Equals(object obj)
        {
            return _stream.Equals(obj);
        }

        public override void Flush()
        {
            _stream.Flush();
        }

        public override Task FlushAsync(CancellationToken cancellationToken)
        {
            return _stream.FlushAsync(cancellationToken);
        }

        public override int GetHashCode()
        {
            return _stream.GetHashCode();
        }

        public override object InitializeLifetimeService()
        {
            return _stream.InitializeLifetimeService();
        }

        public override int Read(Span<byte> buffer)
        {
            return _stream.Read(buffer);
        }

        public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            return _stream.ReadAsync(buffer, offset, count, cancellationToken);
        }

        public override ValueTask<int> ReadAsync(Memory<byte> buffer, CancellationToken cancellationToken = default)
        {
            return _stream.ReadAsync(buffer, cancellationToken);
        }

        public override int ReadByte()
        {
            return _stream.ReadByte();
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return _stream.Seek(offset, origin);
        }

        public override void SetLength(long value)
        {
            _stream.SetLength(value);
        }

        public override string ToString()
        {
            return _stream.ToString();
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            _stream.Write(buffer, offset, count);
        }

        public override void Write(ReadOnlySpan<byte> buffer)
        {
            _stream.Write(buffer);
        }

        public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            return _stream.WriteAsync(buffer, offset, count, cancellationToken);
        }

        public override ValueTask WriteAsync(ReadOnlyMemory<byte> buffer, CancellationToken cancellationToken = default)
        {
            return _stream.WriteAsync(buffer, cancellationToken);
        }

        public override void WriteByte(byte value)
        {
            _stream.WriteByte(value);
        }

        [Obsolete]
        protected override WaitHandle CreateWaitHandle()
        {
            return base.CreateWaitHandle();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        [Obsolete]
        protected override void ObjectInvariant()
        {
            base.ObjectInvariant();
        }
    }
}
