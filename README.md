# HMIN30 -Programmation Cross-Platform avec Xamarin.Forms **` bqz-xamarin `**

## Conception d'une application Cross-Plateforme


### Auteurs :

#### `BEYA NTUMBA Joel`
#### `ZORO-BI ZAH Jean-Emmanuel`
#### `QUENETTE Christophe`

### Lien git de ce repository : 
`https://github.com/cmamon/bqz-xamarin.git`


### **`Utilités`**
  Conception d'une application qui va afficher la liste des messages envoyé au serveur.
  Conception en Xamarin Forms fonctionnant sur les plateformes IOS et/ou Android
  
### **`Cahier des charges`**
  Connection au serveur RESTFUL afin de recevoir les messages envoyés par les montres-connectées(Envoi de message reservé uniquement aux montres-connectées).
  Applicatio composée de trois écrans : **`Affichage par liste`**, **`Affichage par carte`**, **`Affichage par détails`**
  
  **`Affichage par liste`** :
  
    - Cet ran présentera l’ensemble des messages stockés sur le serveur. Il s’agit d’une liste
      vertical défilante, de façon à pouvoir parcourir l’ensemble des messages. Afin de rafraîchir
      la liste, l’utilisateur pourra cliquer un bouton « rafraichir » ou attendre 30 secondes pour
      faire une mise à jour automatique.
    - Les cellules de la liste devront afficher chacune un message. Le design des cellules est libre
      mais devront comporter au moins : le nom de l’émetteur et le début du message (disons les
      50 premiers caractères).
 
  **`Affichage par carte`** :
  
    - L’affichage par carte utilisera les coordonnées GPS des messages pour afficher tous les
      messages sur une carte du monde.
    - Au-dessus de chaque point de la carte devront s’afficher les messages reçus.
    - La carte devra être mise à jour en suivant le principe que l’affichage que par liste. 

  **`Affichage par détails`**:
  
    - L’écran des détails s’active lorsque l’utilisateur clique sur un message. Il permet d’afficher le
      message en entier, mais aussi de voir tous les autres messages de l’utilisateurs (s’il y en a).
    - Les messages étant volatiles (ils peuvent disparaitre après un rafraîchissement de la liste)
      on demandera d’ajouter une fonctionnalité de sauvegarde des messages dit favoris. Ces
      messages seront sauvegardés de façon permanente tant qu’ils seront marqués comme
      favoris. Les messages favoris s’afficheront toujours en premier dans la l’affichage par liste. 
      Ils apparaitront aussi avec une icône spéciale dans les autres vues afin dès les distinguer
      des autres messages non favoris.
    - On souhaite aussi donner à l’utilisateur la possibilité d’associer à un émetteur une couleur
      particulière. Ainsi lors de l’affiche par liste ou par carte, l’utilisateur pourra voir apparaitre
      d’une couleur spécifique, tous les messages provenances de l’émetteur X. 
      
      
