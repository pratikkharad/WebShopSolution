var Validation = {
    validateInput: function (inputId, validationRules) {
        var inputValue = $('#' + inputId).val();
        var errors = [];

        for (var rule in validationRules) {
            switch (rule) {
                case 'required':
                    if (validationRules[rule] && !inputValue) {
                        errors.push(validationRules[rule]);
                    }
                    break;
                case 'minLength':
                    if (validationRules[rule] && inputValue.length < validationRules[rule]) {
                        errors.push('Minimum length is ' + validationRules[rule]);
                    }
                    break;
                case 'maxLength':
                    if (validationRules[rule] && inputValue.length > validationRules[rule]) {
                        errors.push('Maximum length is ' + validationRules[rule]);
                    }
                    break;
                // Add more validation rules as needed
            }
        }

        return errors;
    },

    displayErrors: function (inputId, errors) {
        var errorSpan = $('#' + inputId + '-error');
        if (errors.length > 0) {
            errorSpan.text(errors.join(', ')).show();
        } else {
            errorSpan.hide().text('');
        }
    },

    clearErrors: function (inputId) {
        $('#' + inputId + '-error').hide().text('');
    }
};
