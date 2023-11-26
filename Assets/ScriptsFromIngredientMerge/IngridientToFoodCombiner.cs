using System.Collections.Generic;
using UnityEngine;

namespace ScriptsFromIngredientMerge
{
    public class IngridientToFoodCombiner : MonoBehaviour
    {
        public List<string> recipeTags;

        private List<string> ingredientsInside = new List<string>();
        [SerializeField] private Transform _ovenIngredientGrabberZone;
        [SerializeField] private float _ovenIngredientGrabberZoneRange;
        [SerializeField] private LayerMask _ingredientLayerMask;
        [SerializeField] private string _foodPrefabPath;
        private Color _gizmosColor;
        

        private void Update()
        {
            TakeIngredients();
        }

        private void TakeIngredients()
        {
            Collider2D[] ingredientsInRange = Physics2D.OverlapCircleAll(
                _ovenIngredientGrabberZone.position,
                _ovenIngredientGrabberZoneRange,
                _ingredientLayerMask
            );
        
            if (ingredientsInRange.Length > 0)
            {
                foreach (Collider2D ingredientCollider in ingredientsInRange)
                {
                
                    string ingredientTag = ingredientCollider.tag;

                
                    ingredientsInside.Add(ingredientTag);

                
                    Destroy(ingredientCollider.gameObject);
                }
                CheckRecipe();
            }
        }
        /*
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ingredient"))
        {
            string ingredientTag = other.tag;
            
            ingredientsInside.Add(ingredientTag);
            
            Destroy(other.gameObject);
            
            CheckRecipe();
        }
    }
    */

        private void CheckRecipe()
        {
            if (IngredientsMatchRecipe())
            {
                CreateDish();
            }
        }

        private bool IngredientsMatchRecipe()
        {
            if (ingredientsInside.Count == recipeTags.Count)
            {
                for (int i = 0; i < ingredientsInside.Count; i++)
                {
                    if (ingredientsInside[i] != recipeTags[i])
                    {
                        return false;
                    }
                }
                return true;
            }

            return false;
        }

        private void CreateDish()
        {
            GameObject dishPrefab = Instantiate(Resources.Load(_foodPrefabPath)) as GameObject;

            float offsetX = -2f;
            float offsetY = 1f;

            var position = transform.position;
            dishPrefab.transform.position = new Vector2(position.x + offsetX, position.y + offsetY);
        
            ingredientsInside.Clear();
        }
    
        private void OnDrawGizmos()
        {
            _gizmosColor = Color.yellow;
            Gizmos.color = _gizmosColor;
            Gizmos.DrawWireSphere(_ovenIngredientGrabberZone.position, _ovenIngredientGrabberZoneRange);
        
        }
    
    }
}
