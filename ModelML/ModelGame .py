
# coding: utf-8

# In[36]:


import pandas as pd 
import numpy as np
from IPython import get_ipython
from sklearn.tree import DecisionTreeClassifier
from sklearn.model_selection import train_test_split
from matplotlib import pyplot as plt
import seaborn as sns
import graphviz
import pydotplus
import io
import PIL 
from scipy import misc
from sklearn.tree import export_graphviz
from scipy.stats import stats
import scipy.misc
from scipy.ndimage import imread



# In[37]:


data = pd.read_csv('DataNew.csv', delimiter=',', quotechar='"')
data = pd.read_csv('DataNew.csv', decimal=',')


# In[38]:


type(data)


# In[39]:


data.describe()


# In[40]:


data.head()


# In[41]:


train, test = train_test_split(data, test_size = 0.15)


# In[42]:


print("Training size: {}; test_size: {}". format(len(train), len(test)))


# In[43]:


train.shape


# In[44]:


pos_temp = data[data['correct'] == 1]['correct']
neg_temp = data[data['correct'] == 0]['correct']

fig = plt.figure(figsize=(12, 8))
plt.title("Respuestas correctas / Incorrectas")
pos_temp.hist(alpha = 0.7, bins = 10, label = 'Correctas')
neg_temp.hist(alpha = 0.7, bins = 10, label = 'Incorrectas')
plt.legend(loc = "upper right")


# In[45]:


pos_temp = data[data['correct'] == 1]
neg_temp = data[data['correct'] == 0]

fig = plt.figure(figsize=(12, 8))
pos_temp.hist(alpha = 0.7, bins = 10, label = 'Correctas')
neg_temp.hist(alpha = 0.7, bins = 10, label = 'Incorrectas')
plt.legend(loc = "upper right")


# In[46]:


c = DecisionTreeClassifier(min_samples_split = 100)


# In[47]:


features = ["correct", "playedInterval", "answeredInterval", "firstNote", "expectedNote", "inputNote", "time"]


# In[48]:


x_train = train[features]
y_train = train["inputNote"]

x_test = train[features]
y_test = train["inputNote"]


# In[49]:


y_test


# In[50]:


dt = c.fit(x_train, y_train)


# In[51]:


def show_tree(tree, features, path):
    f = io.StringIO()
    export_graphviz(tree, out_file = f, feature_names = features)
    pydotplus.graph_from_dot_data(f.getvalue()).write_png(path)
    img = misc.imread(path)
    plt.rcParams["figure.figsize"] = (20, 20)
    plt.imshow(img)

import os

os.environ["PATH"] += os.pathsep + 'C:/Program Files (x86)/Graphviz2.38/bin/'

show_tree(dt, features, 'imgTest.png')

y_pred = c.predict(x_test)

from sklearn.metrics import accuracy_score
score = accuracy_score(y_test, y_pred)
print(round(score, 1))
