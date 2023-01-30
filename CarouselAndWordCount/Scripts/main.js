
// just for the demos, avoids form submit
jQuery.validator.setDefaults({
    debug: true,
    success: "valid"
});
$("#testAppForm").validate({
    rules: {
        field: {
            required: true
        }
    }
});
