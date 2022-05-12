using System;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Controls;
using System.Windows;

namespace _6._2_3_Inheritance__abstract_classes__interfaces
{
    public class PasswordStream : Stream
    {
        private readonly Stream _stream;
        private readonly string _password = new string("123");
        public PasswordStream(Stream stream)
        {
            _stream = stream;
        }

        class PasswordWindow : Window
        {
            private readonly PasswordBox _passwordBox;
            public string Password => _passwordBox.Password;

            public PasswordWindow()
            {
                Button okButton = new Button()
                {
                    Content = "Ввод",
                    FontSize = 20,
                    IsDefault = true
                };
                Button cancelButton = new Button()
                {
                    Content = "Отмена",
                    IsCancel = true,
                    FontSize = 20,
                };

                Label passwordLabel = new Label()
                {
                    Content = "Введите пароль",
                    FontSize = 20,
                };

                _passwordBox = new PasswordBox()
                {
                    FontSize = 20,
                };
                Grid grid = new Grid();
                grid.RowDefinitions.Add(new RowDefinition());
                grid.RowDefinitions.Add(new RowDefinition());
                grid.RowDefinitions.Add(new RowDefinition());
                grid.ColumnDefinitions.Add(new ColumnDefinition());
                grid.ColumnDefinitions.Add(new ColumnDefinition());
                Grid.SetRow(passwordLabel, 0);
                Grid.SetRow(_passwordBox, 1);
                Grid.SetRow(okButton, 2);
                Grid.SetRow(cancelButton, 3);
                Grid.SetColumn(passwordLabel, 0);
                Grid.SetColumn(_passwordBox, 0);
                Grid.SetColumn(okButton, 0);
                Grid.SetColumn(cancelButton, 1);
                Grid.SetColumnSpan(passwordLabel, 2);
                Grid.SetColumnSpan(_passwordBox, 2);
                _ = grid.Children.Add(passwordLabel);
                _ = grid.Children.Add(_passwordBox);
                _ = grid.Children.Add(okButton);
                _ = grid.Children.Add(cancelButton);
                Content = grid;
                Height = 330;
                Width = 330;
                SizeToContent = SizeToContent.Height;
                ResizeMode = ResizeMode.CanMinimize;
                WindowState = WindowState.Normal;
                Title = "Ввод пароля";
                okButton.Click += OkButton_Click;
            }

            private void OkButton_Click(object sender, RoutedEventArgs e)
            {
                DialogResult = true;
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

        public override int Read(byte[] buffer, int offset, int count)
        {
            PasswordWindow passwordWindow = new PasswordWindow();
            if (passwordWindow.ShowDialog() == true)
            {
                if (passwordWindow.Password == _password)
                {
                    _ = MessageBox.Show("Авторизация пройдена");
                    return _stream.Read(buffer, offset, count);
                }
                else
                {
                    _ = MessageBox.Show("Неверный пароль");
                    return 0;
                }
            }
            else
            {
                _ = MessageBox.Show("Авторизация не пройдена");
                return 0;
            }
        }
        public override int ReadTimeout { get => _stream.ReadTimeout; set => _stream.ReadTimeout = value; }
        public override int WriteTimeout { get => _stream.WriteTimeout; set => _stream.WriteTimeout = value; }

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

