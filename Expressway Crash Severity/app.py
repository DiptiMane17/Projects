from flask import Flask, render_template, request
import pandas as pd
import pickle
from sklearn.linear_model import LogisticRegression

app = Flask(__name__)
@app.route('/')
def home():
    return render_template('index.html')


# Load the pre-trained model (ensure you save the model after training)
# Replace 'logistic_model.pkl' with the path to your saved model
with open('logistic_model.pkl', 'rb') as file:
    logistic_model = pickle.load(file)


@app.route('/predict', methods=['POST'])
def predict():
    try:
        # Get form data
        light_conditions = int(request.form['light_conditions'])
        sex_of_driver = int(request.form['sex_of_driver'])
        vehicle_type = int(request.form['vehicle_type'])
        speed_limit = int(request.form['speed_limit'])
        road_type = int(request.form['road_type'])
        special_conditions = int(request.form['special_conditions'])
        num_passengers = int(request.form['num_passengers'])

        # Create a dataframe for prediction
        input_data = pd.DataFrame([[
            light_conditions, sex_of_driver, vehicle_type, speed_limit,
            road_type, special_conditions, num_passengers
        ]], columns=[
            'Light_Conditions', 'Sex_Of_Driver', 'Vehicle_Type', 'Speed_limit',
            'Road_Type', 'Special_Conditions_at_Site', 'Number_of_Pasengers'
        ])

        # Make a prediction
        prediction = logistic_model.predict(input_data)[0]
        severity = 'Serious' if prediction == 1 else 'Slight'

        return f"<h3>Predicted Accident Severity: {severity}</h3>"

    except Exception as e:
        return f"<h3>Error: {e}</h3>"

if __name__ == '__main__':
    app.run(debug=True)
