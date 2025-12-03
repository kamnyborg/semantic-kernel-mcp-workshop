# Semantic Kernel Workshop - Lab 2

## Mål: 
- Legge til en plugin
- Bruke plugins for å gi mer informasjon til en LLM

## Instruksjoner:
1. Legg til appsettings
1. Kjør prosjektet og legg merke til at agenten ikke har tilgang til dato og tid
1. Legg til implementasjon for Plugins/DateTimePlugin.cs:

```C#
        [KernelFunction, Description("Get the local time zone name")]
        public string TimeZone()
        {
            return TimeZoneInfo.Local.DisplayName;
        }

        [KernelFunction, Description("Get the current date and time")]
        public string DateWithTime()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
```

Gå i Program.cs og erstatt linje 36 med:
```C#
kernel.ImportPluginFromType<DateTimePlugin>("dateTimePlugin");
```

1. Kjør prosjektet på nytt og legg merke til at agenten nå kjenner til dato og tid
