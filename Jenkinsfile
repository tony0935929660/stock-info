pipeline {
    agent any
    stages {
        stage('Checkout') {
            steps {
                checkout scm
            }
        }
        stage('Build Docker Image') {
            steps {
                sh 'docker build -t stockinfo:latest .'
            }
        }
        stage('Stop Old Containers') {
            steps {
                sh 'docker-compose down || true'
            }
        }
        stage('Deploy') {
            steps {
                sh 'docker-compose up -d --build'
            }
        }
    }
    post {
        always {
            sh 'docker-compose ps'
            sh 'docker ps'
        }
    }
}