<template>
    <div>
        <Navbar />
        <div class="center_vertically">
            <div class="authentication_pane right_align_text">
                <h1 class="right_align_text">Sign Up</h1>
                <input v-model="signUpUsername" class="sign_up_input" placeholder="username">
                <input v-model="signUpPassword" class="sign_up_input" type="password" placeholder="password">
                <br />
                <button @click="signUp()">ClickMe</button>
            </div>
            <img src="https://www.almanac.com/sites/default/files/styles/opengraph/public/image_nodes/chick-close-up-grass-crop.jpg?itok=ebheIGw2" alt="Avatar">
            <div class="authentication_pane">
                <h1>Login</h1>
                <input v-model="loginUsername" placeholder="username">
                <input v-model="loginPassword" type="password" placeholder="password">
                <br />
                <button @click="login()">ClickMe</button>
            </div>      
        </div>    
    </div>
</template>

<script>
import axios from 'axios';

export default {
    data: () => {
        return {
            signUpUsername: '',
            signUpPassword: '',
            loginUsername: '',
            loginPassword: '',
        }
    },
    methods: {
        async signUp() {
            if (this.signUpUsername === '' || this.signUpPassword === '') {
                window.alert("Please enter a username and password to sign up")
            } else {
                const response = await axios.post('https://bright-peeps-api.azurewebsites.net/user', {
                    username: this.signUpUsername,
                    password: this.signUpPassword,
                });
                if (response.status === 200) {
                    this.$router.push({
                        path: '/'
                    })
                }
            }
        },
        async login() {
            if (this.loginUsername === '' || this.loginPassword === '') {
                window.alert("Please enter a username and password to login")
            } else {
                const url = 'https://bright-peeps-api.azurewebsites.net/user/username/' + this.loginUsername;
                const response = await axios.get(url);
                if (response.status === 200) {
                    const lUsername = this.loginUsername;
                    const lPassword = this.loginPassword;
                    if (response.data.result.some(function(peep) {
                        return (peep.username === lUsername && peep.password === lPassword);
                    })) {
                        alert('Authenticated! Now redirecting to homepage');
                        this.$router.push({
                            path: '/'
                        });
                    }
                }
            }
        }
    }
}
</script>

<style scoped>
    img {
        border-radius: 50%;
        width: 150px;
        height: 150px;

    }
    .center_horizontally {
        justify-content: center;
    }
    .center_vertically{
        max-width: 2000px;
        margin-top: 100px;
        display: flex;
        flex-direction: row;
        justify-content: space-evenly;
    }
    .authentication_pane {
        width: 400px;

    }
    .right_align_text {
        text-align: right !important;
    }
    input {
        margin-top: 10px;
        border-radius: 3px;
        padding-right: 5px;
        padding-left: 5px;
        color: #000;
    }
    .sign_up_input {
        text-align: right;
    }
    .sign_up_input::placeholder {
        text-align: right;
    }
    button {
        margin-top: 10px;
        width: 100px;
        height: 40px;
        background-color: #5fe3b0;
        border-radius: 3px;
    }
</style>

