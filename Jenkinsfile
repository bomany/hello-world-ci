pipeline {
  agent {
    docker {
      image 'gableroux/unity3d:2017.3.0f1'
      args '-u root:root  '
    }

  }
  stages {
    stage('Setup') {
      agent any
      steps {
        sh 'chmod +x ./ci/before_script.sh && ./ci/before_script.sh'
      }
    }
    stage('Test') {
      parallel {
        stage('EditMode') {
          environment {
            TEST_PLATFORM = 'editmode'
          }
          steps {
            sh 'chmod +x ./ci/test.sh && ./ci/test.sh'
          }
        }
        stage('PlayMode') {
          environment {
            TEST_PLATFORM = 'playmode'
          }
          steps {
            sh 'chmod +x ./ci/test.sh && ./ci/test.sh'
          }
        }
      }
    }
  }
  environment {
    BUILD_NAME = 'hello-world-ci'
    UNITY_LICENSE_CONTENT = credentials('Unity2017.3.0f1')
  }
}