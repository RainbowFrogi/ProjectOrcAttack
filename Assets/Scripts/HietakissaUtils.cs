namespace HietakissaUtils
{
    using Random = UnityEngine.Random;
    using System.Collections.Generic;
    using UnityEditor;
    using UnityEngine;
    using System.IO;
    using System;

    public static class Extensions
    {
        public static Vector2 Abs(this Vector2 vector)
        {
            Vector2 absoluteVector = new Vector2 (Mathf.Abs(vector.x), Mathf.Abs(vector.y));
            return absoluteVector;
        }

        public static Vector3 Abs(this Vector3 vector)
        {
            Vector3 absoluteVector = new Vector3(Mathf.Abs(vector.x), Mathf.Abs(vector.y), Mathf.Abs(vector.z));
            return absoluteVector;
        }

        public static Vector2 Round(this Vector2 vector, bool roundUp = false)
        {
            int roundedX = Maf.Round(vector.x, roundUp);
            int roundedY = Maf.Round(vector.y, roundUp);

            return new Vector2(roundedX, roundedY);
        }

        public static Vector3 Round(this Vector3 vector, bool roundUp = false)
        {
            int roundedX = Maf.Round(vector.x, roundUp);
            int roundedY = Maf.Round(vector.y, roundUp);
            int roundedZ = Maf.Round(vector.z, roundUp);

            return new Vector3(roundedX, roundedY, roundedZ);
        }

        public static Vector2 RoundToNearest(this Vector2 vector)
        {
            int roundedX = Maf.RoundToNearest(vector.x);
            int roundedY = Maf.RoundToNearest(vector.y);

            return new Vector2(roundedX, roundedY);
        }

        public static Vector3 RoundToNearest(this Vector3 vector)
        {
            int roundedX = Maf.RoundToNearest(vector.x);
            int roundedY = Maf.RoundToNearest(vector.y);
            int roundedZ = Maf.RoundToNearest(vector.z);

            return new Vector3(roundedX, roundedY, roundedZ);
        }

        public static string Remove(this string targetString, string stringToRemove)
        {
            string cutString = targetString.Replace(stringToRemove, "");
            return cutString;
        }

        public static int ToInt(this string targetString)
        {
            if (int.TryParse(targetString, out int result))
            {
                return result;
            }
            else return 0;
        }

        public static int Abs(this int absInt)
        {
            return (int)Maf.Abs(absInt);
        }

        public static float Abs(this float absFloat)
        {
            return Maf.Abs(absFloat);
        }

        public static int Round(this float roundNum, bool roundUp = false)
        {
            return Maf.Round(roundNum, roundUp);
        }

        public static int RoundToNearest(this float num)
        {
            return Maf.RoundToNearest(num);
        }

        public static float RoundToDecimalPlaces(this float num, int decimalPlaces)
        {
            return Maf.RoundToDecimalPlaces(num, decimalPlaces);
        }

        public static float FlipOne(this float num)
        {
            return Maf.FlipOne(num);
        }

        public static Quaternion CameraFlip(this Quaternion rotation)
        {
            Vector3 vectorRotation = rotation.eulerAngles;
            vectorRotation.y -= 180f;
            vectorRotation.x *= -1f;
            Quaternion rot = Quaternion.Euler(vectorRotation);

            return rot;
        }
    }

    /// <summary>
    /// CURRENTLY INT.ABS, FLOAT.ABS, MAF.POINTINRANGE, MAF.FLIPONE, FLOAT.ROUND, FLOAT.ROUNDTONEAREST, MAF.ROUNDTODECIMALPLACES, FLOAT.ROUNDTODECIMALPLACES, FILEUTILITIES, OPTIMIZATION, TIMER, POOL, QUATERNION.FLIP
    /// ARE NOT DOCUMENTED
    /// 
    /// UPDATE HEALTHSYSTEM, NEW CONSTRUCTOR AND WAY TO STOP HEALING IF SETTING REGENDELAY TO -1
    /// </summary>

    public abstract class Maf
    {
        public static float Average(float num1, float num2)
        {
            return (num1 + num2) / 2f;
        }

        public static float Average(float num1, float num2, float num3)
        {
            return (num1 + num2 + num3) / 3f;
        }

        public static int AverageInt(float num1, float num2)
        {
            return RoundToNearest((num1 + num2) / 2f);
        }

        public static int AverageInt(float num1, float num2, float num3)
        {
            return RoundToNearest((num1 + num2 + num3) / 3f);
        }

        public static Vector2 Vector2Average(Vector2 firstVector, Vector2 secondVector)
        {
            float averageX = Average(firstVector.x, secondVector.x);
            float averageY = Average(firstVector.y, secondVector.y);

            return new Vector2(averageX, averageY);
        }

        public static Vector2 Vector2Average(Vector2 firstVector, Vector2 secondVector, Vector2 thirdVector)
        {
            float averageX = Average(firstVector.x, secondVector.x, thirdVector.x);
            float averageY = Average(firstVector.y, secondVector.y, thirdVector.y);

            return new Vector2(averageX, averageY);
        }

        public static Vector3 Vector3Average(Vector3 firstVector, Vector3 secondVector)
        {
            float averageX = Average(firstVector.x, secondVector.x);
            float averageY = Average(firstVector.y, secondVector.y);
            float averageZ = Average(firstVector.z, secondVector.z);

            return new Vector3(averageX, averageY, averageZ);
        }

        public static Vector3 Vector3Average(Vector3 firstVector, Vector3 secondVector, Vector3 thirdVector)
        {
            float averageX = Average(firstVector.x, secondVector.x, thirdVector.x);
            float averageY = Average(firstVector.y, secondVector.y, thirdVector.y);
            float averageZ = Average(firstVector.z, secondVector.z, thirdVector.z);

            return new Vector3(averageX, averageY, averageZ);
        }

        public static float Abs(float absNum)
        {
            return Mathf.Abs(absNum);
        }

        public static int Round(float num, bool roundUp = false)
        {
            if (num % 1 == 0) return (int)num;

            int roundedNum;

            if (roundUp) roundedNum = (int)Math.Ceiling(num);
            else roundedNum = (int)Math.Floor(num);

            return roundedNum;
        }

        public static int RoundToNearest(float num)
        {
            int roundedNum = (int)Math.Round(num, MidpointRounding.AwayFromZero);

            return roundedNum;
        }

        public static float RoundToDecimalPlaces(float num, int decimalPlaces)
        {
            return (float)Math.Round((decimal)num, decimalPlaces);
        }

        public static Vector2 RandomVector2(float minValue, float maxValue)
        {
            Vector2 randomVector;
            randomVector.x = Random.Range(minValue, maxValue);
            randomVector.y = Random.Range(minValue, maxValue);

            return randomVector;
        }

        public static Vector3 RandomVector3(float minValue, float maxValue)
        {
            Vector3 randomVector;
            randomVector.x = Random.Range(minValue, maxValue);
            randomVector.y = Random.Range(minValue, maxValue);
            randomVector.z = Random.Range(minValue, maxValue);

            return randomVector;
        }

        public static float PointInRange(float value, float minRange, float maxRange, bool debug = false)
        {
            if (minRange >= maxRange)
            {
                if (debug) Debug.Log("Max value of range cannot be less than, or equal to min value. Returned 0");
                return 0;
            }
            else if (value > maxRange)
            {
                if (debug) Debug.Log("Given value is greater than the max value of the given range. Returned 1");
                return 1;
            }
            else if (value < minRange)
            {
                if (debug) Debug.Log("Given value is less than the min value of the given range. Returned 0");
                return 0;
            }

            float point;

            if (minRange < 0)
            {
                value += Abs(minRange);
                maxRange += Abs(minRange);

                point = value / maxRange;
            }
            else if (minRange > 0)
            {
                //float toadd = Abs(maxRange);

                //point = Abs((value + toadd) / (minRange + toadd));
                value -= Abs(minRange);
                maxRange -= Abs(minRange);

                point = value / maxRange;
            }
            else
            {
                point = value / maxRange;
            }

            return point;
        }

        public static float PointInRange(float value, float minRange, float maxRange, float multiplier,  bool debug = false)
        {
            if (minRange >= maxRange)
            {
                if (debug) Debug.Log("Max value of range cannot be less than, or equal to min value. Returned 0");
                return 0;
            }
            if (value > maxRange)
            {
                if (debug) Debug.Log("Given value is greater than the max value of the given range. Returned 1 times multiplier");
                return 1 * multiplier;
            }
            if (value < minRange)
            {
                if (debug) Debug.Log("Given value is less than the min value of the given range. Returned 0");
                return 0;
            }

            float point;

            if (minRange < 0)
            {
                //point = Abs((value - minRange) / (maxRange - minRange));
                value += Abs(minRange);
                maxRange += Abs(minRange);

                point = value / maxRange;
                point *= multiplier;
            }
            else if (minRange > 0)
            {
                //float toadd = Abs(maxRange);

                //point = Abs((value + toadd) / (minRange + toadd));
                value -= Abs(minRange);
                maxRange -= Abs(minRange);

                point = value / maxRange;
                point *= multiplier;
            }
            else
            {
                point = value / maxRange;
                point *= multiplier;
            }

            return point;
        }

        public static float FlipOne(float num)
        {
            return Abs(num - 1);
        }
    }

    public class Grid2D<TGridObject>
    {
        TGridObject[,] gridArray;

        public Action OnValueChanged;

        int gridWidth, gridHeight;
        int cellSize = 1;
        Vector3 gridOrigin;

        public Grid2D(int width, int height)
        {
            //Initialize Grid with given parameters
            gridArray = new TGridObject[width, height];

            gridWidth = width;
            gridHeight = height;
        }

        public Grid2D(int width, int height, Vector3 origin, int cellSize)
        {
            //Initialize Grid with given parameters
            gridArray = new TGridObject[width, height];

            gridWidth = width;
            gridHeight = height;
            this.cellSize = cellSize;
            this.gridOrigin = origin;
        }

        public int GetWidth()
        {
            return gridWidth; //Return width of the grid
        }

        public int GetHeight()
        {
            return gridHeight; //Return height of the grid
        }

        public TGridObject GetValue(int x, int y)
        {
            //If given grid position is valid -> get its value, else return default value
            if (IsValidPos(x, y)) return gridArray[x - 1, y - 1];
            else return default(TGridObject);
        }

        public TGridObject GetValue(Vector3 worldPosition)
        {
            //Convert world position to grid position
            int x, y;
            GetWorldToGrid(worldPosition, out x, out y);

            //Try to get grid value at converted grid position
            return GetValue(x, y);
        }

        public void SetValue(int x, int y, TGridObject value)
        {
            //If given grid position is valid -> set its value to given value
            if (IsValidPos(x, y))
            {
                gridArray[x - 1, y - 1] = value;
                if (OnValueChanged != null) OnValueChanged(); //Fire OnValueChanged Event
            }
        }

        public void SetValue(Vector3 worldPosition, TGridObject value)
        {
            //Convert world position to grid position
            int x, y;
            GetWorldToGrid(worldPosition, out x, out y);

            //Try to set grid value at converted grid position
            SetValue(x, y, value);
        }

        public void ClearGrid()
        {
            //Loop through all grid positions and set their values to default
            for (int y = 1; y < gridHeight + 1; y++)
            {
                for (int x = 1; x < gridWidth + 1; x++)
                {
                    //Debug.Log($"Clearing cell at {x}, {y}");
                    SetValue(x, y, default(TGridObject));
                }
            }
        }

        void GetWorldToGrid(Vector3 worldPos, out int x, out int y)
        {
            //Convert world position to grid position
            Vector3 realPos = new Vector3(Mathf.Abs(gridOrigin.x), Mathf.Abs(gridOrigin.y), Mathf.Abs(gridOrigin.z)) + worldPos;

            //Round up grid position to stay consistent with given pos and output grid pos
            x = (int)(realPos.x / cellSize + 0.5f);
            y = (int)(realPos.y / cellSize + 0.5f);
        }

        public bool IsValidPos(int x, int y)
        {
            //Check whether the given grid pos is withing the grid bounds
            if (x > 0 && y > 0 && x <= gridWidth && y <= gridHeight) return true;
            else return false;
        }

        public bool IsValidPos(Vector3 worldPos)
        {
            //Convert world position to grid position
            int x, y;
            GetWorldToGrid(worldPos, out x, out y);

            //Check whether the given grid pos is withing the grid bounds
            return IsValidPos(x, y);
        }
    }

    public class Pool
    {
        Queue<GameObject> poolQueue;

        GameObject poolObject;
        Transform parent;

        public int growSize;

        public Pool(GameObject poolObject, Transform parent, int growSize = 10)
        {
            poolQueue = new Queue<GameObject>();
            this.poolObject = poolObject;
            this.parent = parent;
            this.growSize = growSize;

            GrowPool();
        }

        public GameObject Get(bool debug = false)
        {
            if (poolQueue.Count == 0)
            {
                if (debug) Debug.Log($"Pool has ran out of free objects, growing pool by '{growSize}'");
                GrowPool();
            }

            //Return object
            GameObject getObject = poolQueue.Dequeue();
            getObject.SetActive(true);
            return getObject;
        }

        public GameObject Instantiate(Vector3 position, Quaternion rotation)
        {
            GameObject getObject = Get();

            getObject.transform.position = position;
            getObject.transform.rotation = rotation;

            return getObject;
        }

        public void Return(GameObject returnObject, bool debug = false)
        {
            returnObject.SetActive(false);
            if (!poolQueue.Contains(returnObject)) poolQueue.Enqueue(returnObject);
            else if (debug) Debug.Log($"Pool already contains object '{returnObject}', object has been ignored");
        }

        public void EmptyPool()
        {
            poolQueue.Clear();
        }

        public void GrowPool()
        {
            growSize = Mathf.Clamp(growSize, 1, 1000);

            for (int i = 0; i < growSize; i++)
            {
                GameObject newObject = MonoBehaviour.Instantiate(poolObject, parent.position, Quaternion.identity);
                newObject.transform.parent = parent;

                //Add object to pool
                newObject.SetActive(false);
                poolQueue.Enqueue(newObject);
            }
        }
    }

    namespace Timer
    {
        public class Timer
        {
            public Action OnCompleted;

            TickTimer timer;

            public Timer(float time, GameObject target)
            {
                timer = target.AddComponent<TickTimer>();
                timer.Setup(time, this);
            }

            public void SetCompletionTime(float time)
            {
                timer.SetMaxTime(time);
            }

            public void StopTimer()
            {
                if (timer == null) return;
                timer.Destroy();
            }

            public void PauseTimer()
            {
                if (timer == null) return;
                timer.SetRunning(false);
            }

            public void ResumeTimer()
            {
                if (timer == null) return;
                timer.SetRunning(true);
            }

            public void ToggleTimer()
            {
                if (timer == null) return;
                timer.Toggle();
            }
        }

        class TickTimer : MonoBehaviour
        {
            Timer timer;

            float timerMax;
            float seconds;

            bool running = true;

            public void Setup(float timerMax, Timer timer)
            {
                this.timerMax = timerMax;
                this.timer = timer;
            }

            void Update()
            {
                if (!running) return;

                seconds += Time.deltaTime;

                if (seconds > timerMax)
                {
                    seconds -= timerMax;

                    if (timer.OnCompleted != null) timer.OnCompleted();
                }
            }

            public void SetMaxTime(float time)
            {
                timerMax = time;
            }

            public void SetRunning(bool newRunning)
            {
                running = newRunning;
            }

            public void Toggle()
            {
                running = !running;
            }

            public void Destroy()
            {
                Destroy(this);
            }
        }
    }

    namespace Health
    {
        public class HealthSystem
        {
            //Event variables
            public Action OnHealthChanged;
            public Action OnTookDamage;
            public Action OnDied;
            public Action OnRespawned;

            public bool isAlive { get; private set; }

            //Regen component variable
            HealthRegen regen;

            //Health variables
            public float maxHealth { get; private set; }
            public float currentHealth { get; private set; }

            //All regen variables are optional, by default regen will be disabled and regen will happen every second for 5hp
            public HealthSystem(float maxHealth = 100f)
            {
                //Apply health
                this.maxHealth = maxHealth;
                currentHealth = maxHealth;

                isAlive = true;
            }

            public HealthSystem(float maxHealth = 100f, GameObject regenTarget = null, float regenDelay = 1f, float regenAmount = 5f, bool interruptHealing = false, bool healDecimal = false)
            {
                //Apply health
                this.maxHealth = maxHealth;
                currentHealth = maxHealth;

                isAlive = true;

                if (regenTarget != null) //Is there a target for regen
                {
                    //Setup HealthRegen
                    regen = regenTarget.AddComponent<HealthRegen>();
                    regen.Setup(this, healDecimal);

                    SetRegenDelay(regenDelay);
                    SetRegenAmount(regenAmount);
                }
            }

            //Actions
            public void Damage(float damageAmount)
            {
                if (!isAlive) return; //We are already dead -> don't fire events
                damageAmount = Maf.Abs(damageAmount);

                currentHealth -= damageAmount;

                HealthChangedEvent(); //Attempt to fire the OnHealthChanged Event
                TookDamageEvent(); //Attempt to fire the OnTookDamage Event
            }

            public void DamageDecimal(float damageDecimal)
            {
                Damage(maxHealth * damageDecimal);
            }

            public void Heal(float healAmount)
            {
                if (currentHealth >= maxHealth) return; //We are already at full HP -> don't fire up event
                healAmount = Maf.Abs(healAmount);

                currentHealth += healAmount;

                HealthChangedEvent(); //Attempt to fire the OnHealthChanged Event
            }

            public void HealDecimal(float healDecimal)
            {
                Heal(maxHealth * healDecimal);
            }

            public void HealToFull()
            {
                Heal(maxHealth); //Set current health to maximum
            }

            public void Respawn(float healthMultiplier) //0 to respawn with 0 health 1 to respawn with full health
            {
                currentHealth = maxHealth * healthMultiplier;

                RespawnEvent();
            }


            //Get stats
            public float GetHealth()
            {
                return currentHealth; //Return current health
            }

            public float GetHealthDecimal()
            {
                return currentHealth / maxHealth; //Return health as a decimal ranging from 0 (dead) to 1 (full hp)
            }

            public float GetMaxHealth()
            {
                return maxHealth;
            }

            public bool IsAlive()
            {
                return isAlive;
            }


            //Other methods
            void ClampHealth()
            {
                if (currentHealth <= 0f && isAlive)
                {
                    DiedEvent(); //Current health is under 0 -> we died
                }

                currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth); //Clamp current health between 0 and max health
            }


            //Events
            void HealthChangedEvent()
            {
                ClampHealth(); //Clamp health

                if (OnHealthChanged != null) OnHealthChanged(); //Fire off OnHealthChanged Event if there are subscribers
            }

            void TookDamageEvent()
            {
                if (OnTookDamage != null) OnTookDamage(); //Fire off OnTookDamage Event if there are subscribers
            }

            void DiedEvent()
            {
                isAlive = false; //We are not alive

                if (OnDied != null) OnDied(); //Fire off OnDied Event if there are subscribers
            }

            void RespawnEvent()
            {
                isAlive = true;

                if (OnRespawned != null) OnRespawned();
            }


            //Affect regen
            public void SetRegenDelay(float delay)
            {
                if (regen == null) return;
                regen.SetRegenDelay(delay); //Set the HealthRegen component's RegenDelay if it exists
            }

            public void SetRegenAmount(float amount)
            {
                if (regen == null) return;
                regen.SetRegenAmount(amount); //Set the HealthRegen component's RegenAmount if it exists
            }
        }

        public class HealthRegen : MonoBehaviour
        {
            //HealthSystem variable
            HealthSystem healthSystem;

            //Regen variables
            float regenDelay;
            float regenAmount;
            bool healDecimal;

            bool interrupt;

            bool running;

            //Timer
            float timer;

            void Update()
            {
                if (healthSystem.IsAlive()) HealTimer(); //If we are alive -> regen as normal
            }

            void HealTimer()
            {
                if (!running) return;

                timer += Time.deltaTime; //Increment timer

                if (timer >= regenDelay) //Is timer greater than or equal to regenDelay, if so heal by regenAmount
                {
                    timer -= regenDelay;

                    if (healDecimal) healthSystem.HealDecimal(regenAmount);
                    else healthSystem.Heal(regenAmount);
                }
            }

            void TookDamage()
            {
                timer = 0f;
            }

            public void SetRegenDelay(float delay)
            {
                if (delay == -1) running = false;
                else running = true;

                regenDelay = delay; //Set regen delay
            }

            //Set regen amount
            public void SetRegenAmount(float amount)
            {
                regenAmount = amount; //Set regen amount
            }

            //Setup regen
            public void Setup(HealthSystem healthSystem, bool interrupt, bool healDecimal = false)
            {
                this.healthSystem = healthSystem;
                this.healDecimal = healDecimal;
                this.interrupt = interrupt;

                if (interrupt) healthSystem.OnTookDamage += TookDamage;
            }

            void OnDisable()
            {
                if (interrupt) healthSystem.OnTookDamage -= TookDamage;
            }
        }
    }

    namespace Serializer
    {
        public abstract class SerializerSettings
        {
            static string SAVEDATA_FOLDER = Application.dataPath + "/SaveData/";
            const string FILE_EXTENSION = ".json";
            const string SAVE_FOLDER = "Save_";

            public static string GetSaveDataFolder()
            {
                return SAVEDATA_FOLDER;
            }

            public static string GetFileExtension()
            {
                return FILE_EXTENSION;
            }

            public static string GetSaveFolder()
            {
                return SAVE_FOLDER;
            }

            public static int[] GetSaveIDs()
            {
                string[] saveDirectories = Directory.GetDirectories(SAVEDATA_FOLDER);
                int saveDirectoryCount = saveDirectories.Length;

                int[] saveIDs = new int[saveDirectoryCount];

                for (int i = 0; i < saveDirectoryCount; i++)
                {
                    int saveID = int.Parse(saveDirectories[i].Replace($"{GetSaveDataFolder()}Save_", ""));

                    saveIDs[i] = saveID;
                }

                return saveIDs;
            }

            public static int HighestAvailableSaveID()
            {
                int saveID = 1;

                while (Directory.Exists($"{SAVEDATA_FOLDER}Save_{saveID}"))
                {
                    saveID++;
                }

                return saveID;
            }

            public static void SetActiveSave(int saveID)
            {
                File.WriteAllText($"{SAVEDATA_FOLDER}ActiveSave{FILE_EXTENSION}", saveID.ToString());
            }

            public static int GetActiveSave()
            {
                if (!File.Exists($"{SAVEDATA_FOLDER}ActiveSave{FILE_EXTENSION}")) return 1;
                int activeSaveID = int.Parse(File.ReadAllText($"{SAVEDATA_FOLDER}ActiveSave{FILE_EXTENSION}"));

                return activeSaveID;
            }

            public static bool SaveDataFolderExists()
            {
                return Directory.Exists(SAVEDATA_FOLDER);
            }

            public static bool SaveExists(int saveID = 1)
            {
                return Directory.Exists($"{GetSaveDataFolder()}{SAVE_FOLDER}{saveID}");
            }

            public static bool SaveDataExists(string dataKey, int saveID = 1)
            {
                return File.Exists($"{SAVEDATA_FOLDER}{SAVE_FOLDER}{saveID}/{dataKey}{FILE_EXTENSION}");
            }

            public static void ClearSave(int saveID = 1)
            {
                if (SaveExists(saveID)) Directory.Delete($"{SAVEDATA_FOLDER}{SAVE_FOLDER}{saveID}");
            }

            public static void ClearSaveData(string dataKey, int saveID = 1)
            {
                if (SaveDataExists(dataKey, saveID)) File.Delete($"{SAVEDATA_FOLDER}{SAVE_FOLDER}{saveID}/{dataKey}{FILE_EXTENSION}");
            }

            public static void ClearAllSaves()
            {
                if (!Directory.Exists(SAVEDATA_FOLDER)) return;

                Debug.Log($"Deleted all save data in {SAVEDATA_FOLDER}");
                Directory.Delete(SAVEDATA_FOLDER, true); //Will throw an error if a file containing save data is open
                Directory.CreateDirectory(SAVEDATA_FOLDER);
            }
        }

        /// <summary>
        /// When/if needed, make saving and loading work asynchronously
        /// </summary>

        public class Save<TSaveObject>
        {
            public Save(TSaveObject saveData, string saveKey, int saveID = 1, bool debug = false)
            {
                string SAVEDATA_FOLDER = SerializerSettings.GetSaveDataFolder();
                string FILE_EXTENSION = SerializerSettings.GetFileExtension();
                string SAVE_FOLDER = SerializerSettings.GetSaveFolder();

                if (!Directory.Exists(SAVEDATA_FOLDER))
                {
                    //Create savedata folder, if it doesn't already exist
                    if (debug) Debug.Log($"No SaveData folder found, creating it in '{SAVEDATA_FOLDER}'");

                    Directory.CreateDirectory(SAVEDATA_FOLDER);
                }

                if (!SerializerSettings.SaveExists(saveID))
                {
                    //Create save folder, if it doesn't already exist
                    if (debug) Debug.Log($"No Save folder found, creating it in '{SAVEDATA_FOLDER}{SAVE_FOLDER}{saveID}'");

                    Directory.CreateDirectory($"{SAVEDATA_FOLDER}{SAVE_FOLDER}{saveID}"); 
                }

                string saveDataPath = $"{SAVEDATA_FOLDER}{SAVE_FOLDER}{saveID}/{saveKey}{FILE_EXTENSION}";
                string saveString = JsonUtility.ToJson(saveData);
                //string saveString = Newtonsoft.Json.JsonConvert.SerializeObject(saveData);

                if (File.Exists(saveDataPath) && debug) Debug.Log($"Save data for key '{saveKey}' in save '{saveID}' found, overriding save data");
                File.WriteAllText(saveDataPath, saveString);
            }
        }

        public class Load<TSaveObject>
        {
            public Load(out TSaveObject loadData, string loadKey, int saveID = 1, bool debug = false)
            {
                string SAVEDATA_FOLDER = SerializerSettings.GetSaveDataFolder();
                string FILE_EXTENSION = SerializerSettings.GetFileExtension();
                string SAVE_FOLDER = SerializerSettings.GetSaveFolder();

                if (SerializerSettings.SaveDataFolderExists())
                {
                    //Savedata folder exists
                    if (debug) Debug.Log($"SaveData folder found in '{SAVEDATA_FOLDER}'");
                    if (SerializerSettings.SaveExists(saveID))
                    {
                        //Save exists, return save data if it exists
                        if (debug) Debug.Log($"Save folder found with id '{saveID}'");
                        if (SerializerSettings.SaveDataExists(loadKey, saveID))
                        {
                            //Save data exists for given saveID and key, return save data
                            if (debug) Debug.Log($"Save data found with key '{loadKey}'");

                            string jsonString = File.ReadAllText($"{SAVEDATA_FOLDER}{SAVE_FOLDER}{saveID}/{loadKey}{FILE_EXTENSION}");
                            //loadData = Newtonsoft.Json.JsonConvert.DeserializeObject<TSaveObject>(jsonString);
                            loadData = JsonUtility.FromJson<TSaveObject>(jsonString);
                        }
                        else
                        {
                            //Save data doesn't exist, return default value
                            if (debug) Debug.Log($"No save data found in saveID '{saveID}' for the given key '{loadKey}', has it been manually deleted or has nothing been saved yet?");
                            loadData = default(TSaveObject);
                        }
                    }
                    else
                    {
                        //Save doesn't exist, return default value
                        if (debug) Debug.Log($"No save found for saveID '{saveID}', has it been manually deleted or has nothing been saved yet?");
                        loadData = default(TSaveObject);
                    }
                }
                else
                {
                    //Savedata folder doesn't exist, return default value
                    if (debug) Debug.Log("No SaveData folder found, has it been manually deleted or has nothing been saved yet?");
                    loadData = default(TSaveObject);
                }
            }
        }
    }

    namespace FileUtilities
    {
        abstract class Screenshot
        {
            static string latestScreenshotName;

            static string DataPath
            {
                get => Application.dataPath;
            }

            public static string LastScreenshotPath
            {
                get => $"{DataPath}/Screenshots/{latestScreenshotName}.png";
                private set => LastScreenshotPath = value;
            }

            public static void DeleteAllScreenshots()
            {
                if (Directory.Exists($"{DataPath}/Screenshots"))
                {
                    Directory.Delete($"{DataPath}/Screenshots", true);
                    Directory.CreateDirectory($"{DataPath}/Screenshots");
                }
            }

            public static void CaptureScreenshot(int resolutionMultiplier = 1)
            {
                string screenshotName = DateTime.Now.ToString();

                if (!Directory.Exists($"{DataPath}/Screenshots")) Directory.CreateDirectory($"{DataPath}/Screenshots"); //If Screenshots folder doesn't exist, create one

                string savePath = $"{DataPath}/Screenshots/{screenshotName}.png";

                ScreenCapture.CaptureScreenshot(savePath, resolutionMultiplier); //Take screenshot
                latestScreenshotName = screenshotName;
            }
        }
    }

    abstract class Optimization
    {
        static Dictionary<float, WaitForSeconds> waitDictionary = new Dictionary<float, WaitForSeconds>();

        public static WaitForSeconds WaitSeconds(float time)
        {
            if (waitDictionary.TryGetValue(time, out WaitForSeconds waitTime)) return waitTime;

            waitDictionary[time] = new WaitForSeconds(time);
            return waitDictionary[time];
        }
    }
}