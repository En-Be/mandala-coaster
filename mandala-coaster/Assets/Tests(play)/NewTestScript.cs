using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

namespace Tests
{   
    public class NewTestScript
    {

        // A Test behaves as an ordinary method
        [Test]
        public void SimpleAreEqualAssertion()
        {
            SceneManager.LoadScene(0);

            bool testBool = false;

            Assert.AreEqual(false, testBool);
        }

        [Test]
        public void SimpleHasComponentAssertion()
        {
            GameObject gameObject = new GameObject("test");
            Assert.Throws<MissingComponentException>
            (
                () => gameObject.GetComponent<Rigidbody>().velocity = Vector3.one
            );
        }
        
        [Test]
        public void SimpleIsInTheSceneAssertion()
        {
            SceneManager.LoadScene(0);
            GameObject camera = GameObject.Find("Main Camera");
            Assert.IsNotNull(camera);
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator NewTestScriptWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;

            yield return new WaitForSeconds(5);
            Debug.Log(Time.realtimeSinceStartup);

        }
    }
}
