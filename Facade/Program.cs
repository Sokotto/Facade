using System;

namespace Facade
{
    //Графика
    class GraphicsSystem
    {
        public void Initialize()
        {
            Console.WriteLine("Инициализация графической подсистемы...");
        }

        public void Render()
        {
            Console.WriteLine("Отрисовка кадра...");
        }

        public void Shutdown()
        {
            Console.WriteLine("Остановка графической подсистемы.");
        }
    }

    //Звук
    class AudioSystem
    {
        public void Initialize()
        {
            Console.WriteLine("Инициализация звуковой подсистемы...");
        }

        public void PlayBackgroundMusic()
        {
            Console.WriteLine("Воспроизведение фоновой музыки...");
        }

        public void Shutdown()
        {
            Console.WriteLine("Остановка звуковой подсистемы.");
        }
    }

    //Управление
    class InputSystem
    {
        public void Initialize()
        {
            Console.WriteLine("Инициализация системы управления...");
        }

        public void Shutdown()
        {
            Console.WriteLine("Остановка системы управления.");
        }
    }

    //Сохранения
    class SaveSystem
    {
        public void Load()
        {
            Console.WriteLine("Загрузка сохранения...");
        }

        public void Save()
        {
            Console.WriteLine("Сохранение игры...");
        }
    }

    //Игрок
    class PlayerSystem
    {
        public void Create()
        {
            Console.WriteLine("Создание игрока...");
        }

        public void Destroy()
        {
            Console.WriteLine("Остановка игрока.");
        }
    }

    //Фасад
    class GameFacade
    {
        private GraphicsSystem graphics;
        private AudioSystem audio;
        private InputSystem input;
        private SaveSystem save;
        private PlayerSystem player;

        public GameFacade()
        {
            graphics = new GraphicsSystem();
            audio = new AudioSystem();
            input = new InputSystem();
            save = new SaveSystem();
            player = new PlayerSystem();
        }

        public void StartGame()
        {
            Console.WriteLine("--- ЗАПУСК ИГРЫ ---\n");
            graphics.Initialize();
            audio.Initialize();
            input.Initialize();
            save.Load();
            player.Create();

            audio.PlayBackgroundMusic();
            graphics.Render();
            Console.WriteLine("\nИгра запущена!\n");
        }

        public void ExitGame()
        {
            Console.WriteLine("--- ЗАВЕРШЕНИЕ ИГРЫ ---\n");
            save.Save();
            player.Destroy();
            input.Shutdown();
            audio.Shutdown();
            graphics.Shutdown();
            Console.WriteLine("\nИгра завершена.\n");
        }
    }

    //Клиент
    class Program
    {
        static void Main(string[] args)
        {
            GameFacade game = new GameFacade();
            game.StartGame();

            Console.WriteLine("--- Игровой процесс ---\n");
            game.ExitGame();
            Console.ReadKey();
        }
    }
}
